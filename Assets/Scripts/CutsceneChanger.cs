using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneChanger : MonoBehaviour
{
    public int sceneIndex;
    // Start is called before the first frame update
    private void OnEnable()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
