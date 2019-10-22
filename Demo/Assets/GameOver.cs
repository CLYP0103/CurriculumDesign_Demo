﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Start");
        }
    }

    public void Continue() {
        SceneManager.LoadScene("MapWithCamera");
    }

    public void Quit() {
        SceneManager.LoadScene("Start");
    }
}
