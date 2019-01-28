using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragOperation : MonoBehaviour
{

    private bool isDrag = false;
    private bool isCheck = false;
    private bool isSlide = false;
    private GameObject target = null;

    private RectTransform moveTarget = null;
    private ScrollRect range = null;
    public GameObject canvas;
    public float LeftX = 0;
    public float UpY = 0;
    public float RightX = 0;
    public float DownY = 0;

    //int m = -1;

    void Start()
    {
    }

    void Update()
    {

        

        if (/*Input.GetMouseButtonDown(0) */Input.GetTouch(0).phase==TouchPhase.Began&& !isCheck)
        {
            List<RaycastResult> res = GetOverUI(canvas);
            if (res == null) return;
            isCheck = true;

            if (target == null)  //存储第一次点击的目标
            {
                for (int i = 0; i < res.Count; i++)
                {
                    if (res[i].gameObject.tag == "material")
                    {
                        target = res[i].gameObject;
                    }
                }
            }
        }

        if (/*Input.GetMouseButton(0) */Input.GetTouch(0).phase == TouchPhase.Moved && isCheck)//判断是移动 还是拖动
        {
            if (isDrag) { return; }
            List<RaycastResult> res = GetOverUI(canvas);
            if (res == null) return;
            isSlide = false;

            for (int j = 0; j < res.Count; j++)
            {
                if (res[j].gameObject.tag == "range")
                {
                    isSlide = true;
                    range = res[j].gameObject.GetComponent<ScrollRect>();
                    break;
                }
            }

            if (!isSlide)
            {
                isDrag = true;
                isCheck = false;
                if (range != null)
                    range.vertical = false;
            }

        }
        if (/*Input.GetMouseButtonUp(0)*/Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            isCheck = false;
            target = null;
            if (range != null)
            {
                range.vertical = true;
                range = null;
            }
            if (isDrag)
            {
                isDrag = false;               
                Vector2 position;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), /*Input.mousePosition*/Input.GetTouch(0).position, null, out position);
                if (!(position.x <= RightX && position.x >= LeftX && position.y <= UpY && position.y >= DownY))
                    Destroy(moveTarget.gameObject);
                else
                {
                    Rigidbody2D rigidbody = moveTarget.gameObject.AddComponent<Rigidbody2D>();
                    rigidbody.gravityScale = 20;
                    BoxCollider2D boxCollider = moveTarget.gameObject.AddComponent<BoxCollider2D>();
                    boxCollider.offset = moveTarget.sizeDelta * 0.5f;
                    boxCollider.size = moveTarget.sizeDelta;

                }
                moveTarget.gameObject.tag = "Untagged";
                moveTarget = null;
            }
        }

        if (isDrag)
        {
            if (moveTarget == null)
            {
                if (target == null) { isDrag = false; return; }
                GameObject go = Instantiate(target);
                moveTarget = go.GetComponent<RectTransform>();
                moveTarget.SetParent(transform);

                moveTarget.sizeDelta = target.GetComponent<RectTransform>().sizeDelta;
                moveTarget.pivot = Vector2.zero;
                moveTarget.anchoredPosition = target.transform.position;
                            
            }
            if (moveTarget != null)
            {
                Vector2 position;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), /*Input.mousePosition*/Input.GetTouch(0).position, null, out position);
#if UNITY_EDITOR
                moveTarget.anchoredPosition = position;
#else
                moveTarget.anchoredPosition = position-new Vector2(0,moveTarget.sizeDelta.y);
#endif
                
            }
        }

    }
    public List<RaycastResult> GetOverUI(GameObject canvas)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position =/*Input.mousePosition*/Input.GetTouch(0).position;
        GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);
        if (results.Count != 0)
        {
            return results;
        }

        return null;
    }

}
