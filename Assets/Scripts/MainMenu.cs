﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : LevelLoader
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMain()
    {
        LoadMainMenu();
    }

}
