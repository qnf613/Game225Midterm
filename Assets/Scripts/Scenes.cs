﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void loadGame()
    {
        Application.LoadLevel(1);
    }

    public void loadCredit()
    {
        Application.LoadLevel(2);
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Exit the Game");
    }

    public void backToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
