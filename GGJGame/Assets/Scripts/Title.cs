using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Title : MonoBehaviour
{
    public Text Quest;
    public Text Answer;
    public GameObject Block;
    public GameObject RightScene;
    // Start is called before the first frame update
    public void SetQuest(string Content)
    {
        Quest.text = Content;
        Block.SetActive(false);
        Quest.color = new Color(Quest.color.r, Quest.color.g, Quest.color.b, 1.0f);
    }

    public void SetAnswer(string Content)
    {
        Debug.Log(Content);
        if (Quest.text == Content)
        {
            ResetAnswer();
            //正确答案的效果在这里
            StartCoroutine(ShowRightScene());
        }
        else
            Incorrect(Content);
    }

    private void Incorrect(string content)
    {
        Quest.color = new Color(Quest.color.r, Quest.color.g, Quest.color.b, 0.2f);
        Answer.text = content;
        Answer.gameObject.SetActive(true);
        Block.SetActive(true);
    }

    private void ResetAnswer()
    {
        Block.SetActive(false);
        Answer.text = null;
        Answer.gameObject.SetActive(false);
        Quest.color = new Color(Quest.color.r, Quest.color.g, Quest.color.b, 1.0f);
    }

    private IEnumerator ShowRightScene()
    {
        yield return new WaitForSeconds(3);
        RightScene.SetActive(true);
        Quest.text = null;
    }
}