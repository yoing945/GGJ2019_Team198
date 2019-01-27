using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MaterialData
{
    public string Name;
    public bool IsLeft;
    public string Label;

    public MaterialData(string name, bool left, string label)
    {
        Name = name;
        IsLeft = left;
        Label = label;
    }
}

public class GenerateMaterials : MonoBehaviour
{
    public Transform root_left;
    public Transform root_right;
    public GameObject prefab_mat;
    //基本素材列表
    private List<MaterialData> basicMatList = new List<MaterialData>();

    public Button btn_compose;
    public Transform root_drag;

    public GameObject flash;
    //合成素材列表
    private Dictionary<string, GameObject> newMatDic = new Dictionary<string, GameObject>();

    public Image photo_bg;
    public Transform root_char;
    public GameObject prefab_char;
    private List<Vector2> photo_char_pos = new List<Vector2>();
    //按生成顺序存放的list，需要清空
    private List<Sprite> tempOrderSprList = new List<Sprite>();
    private List<Vector2> tempOrderVec2List = new List<Vector2>();

    public Title title;

    void Start()
    {
        LoadRes();
        GenerateMats();
        if (btn_compose != null)
            btn_compose.onClick.AddListener(OnBtnComposeClick);
    }

    private void LoadRes()
    {
        var resPos = Resources.Load("PosSchema") as Res;
        if (resPos != null)
            photo_char_pos = resPos.photoPos;
        var resMaterial = Resources.Load("BasicMatSchema") as ResMaterial;
        if (resMaterial != null)
            basicMatList = resMaterial.basicMatData;
    }

    private void GenerateMats()
    {
        if (prefab_mat == null)
            return;

        for (int i = 0; i < basicMatList.Count; i++)
            GenerateMat(basicMatList[i]);
    }

    private GameObject GenerateMat(MaterialData data)
    {
        GameObject mat = Instantiate(prefab_mat);
        mat.GetComponentInChildren<Text>().text = data.Name;
        //显示名字和合成标签可能不同
        MaterialProperty prop = mat.AddComponent<MaterialProperty>();
        prop.SetProperty(data.Name, data.IsLeft, data.Label);
        if (data.IsLeft)
            mat.transform.SetParent(root_left);
        else
            mat.transform.SetParent(root_right);
        return mat;
    }

    private void OnBtnComposeClick()
    {
        AudioSource audio = btn_compose.GetComponent<AudioSource>();
        audio.Play();
        StartCoroutine(Compose());

    }

    private IEnumerator Compose()
    {
        if (root_drag.childCount < 2)
            yield break;
        //得到合成因子，并删除素材
        string[] str_arr = new string[root_drag.childCount];
        for (int i = 0; i < str_arr.Length; i++)
        {
            Transform mat = root_drag.GetChild(i);
            str_arr[i] = mat.GetComponentInChildren<MaterialProperty>().Label;
            Destroy(root_drag.GetChild(i).gameObject);
        }

        //播放闪光动画
        if (flash != null)
        {
            flash.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            flash.SetActive(false);
        }

        //合成新素材(不重复)
        string newMat = CombineController.DoCombineByNetRelation(str_arr);
        if (!string.IsNullOrEmpty(newMat))
        {
            //每次合成拍出照片
            var photoSprites = CombineController.getResultSprites(str_arr);
            if (photoSprites != null)
            {
                ClearPhoto();
                if (photoSprites.Count > 0 && photo_bg != null)
                    photo_bg.sprite = photoSprites[0];
                if (photoSprites.Count > 1 && prefab_char != null)
                {
                    //每次生成前打乱固定位置
                    MessPosOrder();
                    
                    if (photoSprites.Count - 1 < photo_char_pos.Count)
                    {
                        for (int i = 1; i < photoSprites.Count; i++)
                        {
                            tempOrderSprList.Add(photoSprites[i]);
                            tempOrderVec2List.Add(photo_char_pos[i - 1]);
                        }
                        GetGenerateOrder();
                    }
                    for (int i = 0; i < tempOrderVec2List.Count; i++)
                        GenerateChar(tempOrderSprList[i], tempOrderVec2List[i]);
                }
            }

            string name = ElementNameMgr.getInstance().getElementCNName(newMat);
            //非照片生成素材
            if (!CombineController.isInResultList(newMat))
            {
                if (newMatDic.ContainsKey(newMat))
                {
                    //重复的提示效果
                    var mat = newMatDic[newMat];
                    mat.SetActive(false);
                    yield return new WaitForSeconds(0.2f);
                    mat.SetActive(true);
                }
                else
                {
                    var mat = GenerateMat(new MaterialData(name, false, newMat));
                    newMatDic.Add(newMat, mat);
                }
            }
            else
            {
                if(title != null)
                    StartCoroutine(title.SetAnswer(name));
            }
        }
    }

    private GameObject GenerateChar(Sprite spr, Vector2 pos)
    {
        GameObject character = Instantiate(prefab_char);
        character.GetComponent<Image>().sprite = spr;
        character.transform.SetParent(root_char);
        var rt = character.GetComponent<RectTransform>();
        rt.localScale = Vector3.one;
        rt.anchoredPosition = pos;
        return character;
    }

    private void MessPosOrder()
    {
        int sum = photo_char_pos.Count;
        for (int i = 0; i < sum; i++)
        {
            int rand = Random.Range(0, sum);
            var item = photo_char_pos[rand];
            photo_char_pos.RemoveAt(rand);
            photo_char_pos.Add(item);
        }
    }

    private void GetGenerateOrder()
    {
        //UI根据Y值从大到小的顺序
        int sum = tempOrderVec2List.Count;
        for (int i = 0; i < sum; i++)
        {
            int maxIndex = sum - 1 - i;
            var maxItem = tempOrderVec2List[maxIndex];
            for (int j = maxIndex - 1; j >= 0; j--)
            {
                if (tempOrderVec2List[j].y > maxItem.y)
                {
                    maxItem = tempOrderVec2List[j];
                    maxIndex = j;
                }
            }
            tempOrderVec2List.RemoveAt(maxIndex);
            tempOrderVec2List.Add(maxItem);
            //同步sprite顺序
            var item = tempOrderSprList[maxIndex];
            tempOrderSprList.RemoveAt(maxIndex);
            tempOrderSprList.Add(item);
        }
    }

    public void ClearPhoto()
    {

        if(root_char != null)
        {
            for (int i = 0; i < root_char.childCount; i++)
                Destroy(root_char.GetChild(i).gameObject);
        }
        if (photo_bg != null)
            photo_bg.sprite = null;

        //每次生成人物前清空
        tempOrderSprList.Clear();
        tempOrderVec2List.Clear();
    }
}