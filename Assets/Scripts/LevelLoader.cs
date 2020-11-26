using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Transition is made everytime we change scenes
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadLevel1()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void LoadLevel2()
    {
        StartCoroutine(LoadLevel(2));
    }
    public void LoadLevel3()
    {
        StartCoroutine(LoadLevel(3));
    }
    public void LoadLevel4()
    {
        StartCoroutine(LoadLevel(4));
    }
    public void LoadLevel5()
    {
        StartCoroutine(LoadLevel(5));
    }
    public void LoadLevel6()
    {
        StartCoroutine(LoadLevel(6));
    }
    public void LoadLevel7()
    {
        StartCoroutine(LoadLevel(7));
    }
    public void LoadLevel8()
    {
        StartCoroutine(LoadLevel(8));
    }
    public void LoadLevel9()
    {
        StartCoroutine(LoadLevel(9));
    }
    public void LoadLevel10()
    {
        StartCoroutine(LoadLevel(10));
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
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
