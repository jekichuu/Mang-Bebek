using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : LevelLoader
{
    // Variable indicating whether the game is paused or not
    public static bool gameIsPaused = false;
    // Referencing the UI for option menu
    public GameObject optionMenuUI;

    private void Update()
    {
        // Pauses or resumes the game when escaped is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused) Resume();
            else Pause();
        }
    }
    public void RestartLevel()
    {
        ReloadLevel(); // Method from LevelLoader
    }
    
    public void ToMenu()
    {
        LoadMainMenu(); // Method from LevelLoader
    }

    public void Pause()
    {
        // Opens up Options UI and freezes the game
        optionMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    
    public void Resume()
    {
        // Closes Options UI and continues the game
        optionMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
