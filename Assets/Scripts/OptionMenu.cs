using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : LevelLoader
{

    public static bool gameIsPaused = false;
    public GameObject optionMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused) Resume();
            else Pause();
        }
    }
    public void RestartLevel()
    {
        ReloadLevel();
    }
    
    public void ToMenu()
    {
        LoadMainMenu();
    }

    void Pause()
    {
        
    }
    
    void Resume()
    {

    }
}
