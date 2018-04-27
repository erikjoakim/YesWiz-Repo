﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public HandleInput handleInput;
    private static GameManager gm;
    private GameManager() { }
    
    public static GameManager GM
    {
        get 
        {
            if (gm == null)
            {
                gm = new GameManager();
            }
            return gm;
        }
    }

    private void Start()
    {
        
    }
}
