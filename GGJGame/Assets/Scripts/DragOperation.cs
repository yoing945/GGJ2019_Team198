using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragOperation : MonoBehaviour
{


    private Vector3 lastMousePosition = Vector3.zero;
    private bool isDrag = false;
    private GameObject target = null;

    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(target);

        }

        if (isDrag)
        {
            if (target == null)
            {
                GameObject go = GetOverUI(canvas);
                if (go == null) {
                    isDrag = false;
                    return;
                }
                target = Instantiate(go);
                target.transform.SetParent(transform);
                target.GetComponent<RectTransform>().sizeDelta = go.GetComponent<RectTransform>().sizeDelta;
                //target.transform.position = go.transform.position;
                target.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
            }
            //target.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
        }

    }
    public GameObject GetOverUI(GameObject canvas)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);
        if (results.Count != 0)
        {
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.tag == "material")
                    return results[i].gameObject;
            }

        }

        return null;
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
                
                if (target == null)
                {
                    //target = Instantiate(prefab_mat);
                    target.transform.SetParent(transform);
                    target.transform.position = transform.position;
                }
                Vector3 offset = Input.mousePosition;
                target.transform.position = new Vector3(hit.point.x, hit.point.y, hit.transform.position.z);
                Debug.DrawLine(ray.origin, hit.point);
            }
        }


    }

}
