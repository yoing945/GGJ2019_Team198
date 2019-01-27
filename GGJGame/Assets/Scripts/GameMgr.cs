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
    void Start()
    {

    }

    void Update()
    {
    }

    public void OpenMainPanel()
    {
        startGame.gameObject.SetActive(false);
        mainPanel.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextGame()
    {
        //清空Box,初始化,隐藏
        rightScene.SetActive(true);
                
    }

}
