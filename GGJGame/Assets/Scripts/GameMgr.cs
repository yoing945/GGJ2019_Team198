using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public Transform startGame;
    public Transform mainPanel;
    public GameObject rightScene;

    private void Awake()
    {
        startGame.gameObject.SetActive(true);
    }

    public void OpenMainPanel()
    {
        startGame.gameObject.SetActive(false);
        mainPanel.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void NextGame()
    {
        //清空Box,初始化,隐藏
        if (mainPanel != null)
        {
            var gm = mainPanel.GetComponent<GenerateMaterials>();
            if (gm != null)
                gm.ClearPhoto();
        }
        rightScene.SetActive(false);
    }
}