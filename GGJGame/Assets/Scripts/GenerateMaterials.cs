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
    public List<MaterialData> basicMatList = new List<MaterialData>();

    public Button btn_compose;
    public Transform root_drag;

    public GameObject flash;
    //合成素材列表
    private Dictionary<string, GameObject> newMatDic = new Dictionary<string, GameObject>();

    public Image photo_bg;
    public Transform root_char;
    public GameObject prefab_char;
    private List<Vector2> photo_char_pos = new List<Vector2>();
    
    void Start()
    {
        //读表生成每关所需素材
        LoadRes();
        GenerateMats();
        if (btn_compose != null)
        {
            btn_compose.onClick.AddListener(OnBtnComposeClick);
        }
    }

    private void LoadRes()
    {
        var res = Resources.Load("PosSchema") as Res;
        if(res != null)
        {
            photo_char_pos = res.photoPos;
        }
    }

    private void GenerateMats()
    {
        if (prefab_mat == null)
            return;

        for (int i = 0; i < basicMatList.Count; i++)
        {
            GenerateMat(basicMatList[i]);
        }
    }

    private GameObject GenerateMat(MaterialData data)
    {
        GameObject mat = Instantiate(prefab_mat);
        mat.GetComponentInChildren<Text>().text = data.Name;
        //显示名字和合成标签可能不同
        MaterialProperty prop = mat.AddComponent<MaterialProperty>();
        prop.SetProperty(data.Name, data.IsLeft, data.Label);
        if (data.IsLeft)
        {
            mat.transform.SetParent(root_left);
        }
        else
        {
            mat.transform.SetParent(root_right);
        }
        return mat;
    }

    private void OnBtnComposeClick()
    {
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

        //照片还是新素材？

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
            //判断是照片还是素材
            if (CombineController.isInResultList(newMat))
            {
                //显示
                var photoSprites = CombineController.getResultSprites(str_arr);
                if (photoSprites.Count > 0 && photo_bg != null)
                    photo_bg.sprite = photoSprites[0];
                if (photoSprites.Count > 1 && prefab_char != null)
                {
                    //每次生成前打乱固定位置
                    MessPosOrder();
                    for (int i = 1; i < photoSprites.Count; i++)
                    {
                        GenerateChar(photoSprites[i], i);
                    }
                }
                yield break;
            }

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
                string name = ElementNameMgr.getInstance().getElementCNName(newMat);
                var mat = GenerateMat(new MaterialData(name, false, newMat));
                newMatDic.Add(newMat, mat);
            }
        }
    }

    private GameObject GenerateChar(Sprite spr, int index)
    {
        GameObject character = Instantiate(prefab_char);
        character.GetComponent<Image>().sprite = spr;
        character.transform.SetParent(root_char);
        if (photo_char_pos.Count > index)
            character.GetComponent<RectTransform>().anchoredPosition = photo_char_pos[index];
        return character;
    }

    private void MessPosOrder()
    {
        int sum = photo_char_pos.Count;
        for(int i = 0; i < sum; i++)
        {
            int rand = Random.Range(0, sum);
            var item = photo_char_pos[rand];
            photo_char_pos.RemoveAt(rand);
            photo_char_pos.Add(item);
        }
    }
}