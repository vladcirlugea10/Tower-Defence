﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string level = "Level1";
    public void Play()
    {
        SceneManager.LoadScene(level);
    }
    public void Quit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}