using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform startGame;
    
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
}
