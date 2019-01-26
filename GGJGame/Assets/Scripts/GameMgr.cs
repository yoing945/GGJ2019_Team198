using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public Transform startGame;
    public Transform mainPanel;

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
}
