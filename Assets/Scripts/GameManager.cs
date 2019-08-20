using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Board boardPrefab;

    private Board boardInstance;

    void Start()
    {
        GameStart();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Restart();
        }
    }

    private void GameStart()
    {
        boardInstance = Instantiate(boardPrefab) as Board;
        boardInstance.Generate();
    }

    private void Restart()
    {
        Destroy(boardInstance.gameObject);
        GameStart();
    }
}
