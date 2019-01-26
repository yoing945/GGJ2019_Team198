using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Title : MonoBehaviour
{
    public Text Quest;
    public Text Answer;
    public GameObject Block;
    // Start is called before the first frame update
    public void SetQuest(string Content)
    {
        Quest.text = Content;
        Block.SetActive(false);
        Quest.color = new Color(Quest.color.r, Quest.color.g, Quest.color.b, 1.0f);
    }
    public void SetAnswer(string Content)
    {
        if(Quest.text == Content)
        {
            Block.SetActive(false);
            //正确答案的效果在这里
        }
        else
        {
            Incorrect();
        }
    }
    private void Incorrect()
    {
        Quest.color = new Color(Quest.color.r, Quest.color.g, Quest.color.b, 0.2f);
        Answer.gameObject.SetActive(true);
        Block.SetActive(true);
    }
}
