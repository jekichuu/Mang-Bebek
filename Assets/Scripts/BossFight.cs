using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BossFight : MonoBehaviour
{
    // Referencing necessary GameObjects, Timeline, and Scripts
    public PlayableDirector stageChangeScene;
    public GameObject cutsceneUI;
    public GameObject enemies;
    public GameObject player;
    EnemiesBehaviour enemiesBehaviour;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        // Calls on the cutscene and changes certain values after 10 seconds of not dying (by standing still)
        Invoke("ChangeStage", 20f);
        enemiesBehaviour = enemies.GetComponentInChildren<EnemiesBehaviour>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void ChangeStage()
    {
        // cutsceneUI deactivated at start to not block the level
        cutsceneUI.SetActive(true);
        // Plays the cutscene timeline
        stageChangeScene.Play();

        enemiesBehaviour.isPowered = true;
        playerMovement.isPowered = true;
    }
}
