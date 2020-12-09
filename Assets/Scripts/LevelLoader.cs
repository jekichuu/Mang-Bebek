using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject levelNotReachedSign;

    // Transition is made everytime scene changes
    public Animator transition;
    public float transitionTime = 1f;

    public virtual void Start()
    {
        PlayerPrefs.GetInt("LevelReached", 1); // Gets highest level reached by player, defaulted to 1 if there is none
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadCertainLevel(int levelIndex)
    {   
        if (PlayerPrefs.GetInt("LevelReached") >= levelIndex) // Checks wether the level to be accessed has been unlocked
        {
            StartCoroutine(LoadLevel(levelIndex));
        }
        else levelNotReachedSign.SetActive(true); // Activates level not reached notice
    }
    public void LoadLevel1()
    {
        StartCoroutine(LoadLevel(12)); // Loads the opening cutscene first
    }
    public void LoadEnd() // Load the ending cutscene
    {
        StartCoroutine(LoadLevel(13));
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    // Coroutine to make the game wait for the transition before changing scenes
    IEnumerator LoadLevel(int levelIndex)
    {
        Time.timeScale = 1f; // Unpauses the game if it's paused

        transition.SetTrigger("Start"); // Triggers the fade to black screen transition

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
