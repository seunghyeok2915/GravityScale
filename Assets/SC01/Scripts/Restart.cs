﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
