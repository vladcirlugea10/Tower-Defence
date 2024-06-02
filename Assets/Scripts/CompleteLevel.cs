using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "Main Menu";

    public string nextlevel = "Level2";
    public int levelToUnlock = 2;
    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextlevel);
    }
    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
