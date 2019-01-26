using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MaterialData
{
    public string Name;
    public bool IsLeft;
}

public class GenerateMaterials : MonoBehaviour
{
    public Transform root_left;
    public Transform root_right;
    public GameObject prefab_mat;

    public List<MaterialData> matList = new List<MaterialData>();
    // Start is called before the first frame update
    void Start()
    {
        //读表生成每关所需素材
        GenerateMats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateMats()
    {
        if (prefab_mat == null)
            return;

        for (int i = 0; i < matList.Count; i++)
        {
            GameObject mat = Instantiate(prefab_mat);
            mat.GetComponentInChildren<Text>().text = matList[i].Name;
            if (matList[i].IsLeft)
            {
                mat.transform.SetParent(root_left);
            }
            else
            {
                mat.transform.SetParent(root_right);
            }
        }
    }
}
