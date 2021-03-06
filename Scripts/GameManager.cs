﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private BoardManager boardManager;

	void Awake () {
		if(instance == null)
        {
            instance = this;
        }

        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        boardManager = GetComponent<BoardManager>();

        InitGame();
	}

    void InitGame()
    {
        boardManager.SetUp();
    }
}
