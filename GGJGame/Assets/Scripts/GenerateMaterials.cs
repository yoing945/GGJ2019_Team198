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
    public Transform root_drag;

    public List<MaterialData> matList = new List<MaterialData>();

    private bool isDrag = false;
    private GameObject target = null;
    // Start is called before the first frame update
    void Start()
    {
        //读表生成每关所需素材
        GenerateMats();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrag = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }

        RayMove();
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

    private void RayMove()
    {
        
        if (!isDrag) return;
       

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (isDrag)
        {

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("AAAAAAA");
                if (target == null)
                {
                    target = Instantiate(prefab_mat);
                    target.transform.SetParent(root_drag);
                    target.transform.position = transform.position;
                }
                Vector3 offset = Input.mousePosition;
                target.transform.position = new Vector3(hit.point.x, hit.point.y, hit.transform.position.z);
                Debug.DrawLine(ray.origin, hit.point);
            }
        }


    }
}
