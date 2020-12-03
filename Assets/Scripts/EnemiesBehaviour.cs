using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehaviour : MonoBehaviour
{
    // Enemies' Left and Right Movement Boundaries
    private GameObject rightBoundary;
    private GameObject leftBoundary;

    public float speed;
    public bool MoveRight;
    private Vector3 tempPos;
    // bossFight bool to give enemies on the last level no delay when teleporting
    public bool bossFight = false;
    // isPowered bool to indicate 2nd phase of the boss when true
    public bool isPowered = false;

    // Start is called before the first frame update
    void Start()
    {
        // Temporary position to store object's original x position
        tempPos = transform.position;
        // Referencing the boundaries' respective GameObject
        rightBoundary = GameObject.FindGameObjectWithTag("rightWall");
        leftBoundary = GameObject.FindGameObjectWithTag("leftWall");
    }

    // Update is called once per frame
    void Update()
    {
        // Sets up the enemies' movement according to their direction
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        // Teleports enemies to the other side of the screen
        if (!bossFight)
        {
            if (trig.gameObject.CompareTag("rightWall") && MoveRight)
            {
                StartCoroutine(TeleportLeft());
            }
            else if (trig.gameObject.CompareTag("leftWall") && !MoveRight)
            {
                StartCoroutine(TeleportRight());
            }
        }
        else
        {
            if (trig.gameObject.CompareTag("rightWall") && MoveRight)
            {
                BossFightTeleportLeft();
            }
            else if (trig.gameObject.CompareTag("leftWall") && !MoveRight)
            {
                BossFightTeleportRight();
            }
        }
        // Destroys the enemies when the player touches them during 2nd phase of boss fight 
        //if (trig.gameObject.CompareTag("Player") && isPowered)
        //{
        //    GameObject.Destroy(gameObject);
        //}
    }   
    IEnumerator TeleportRight()
    {
        yield return new WaitForSeconds(1f);
        tempPos.x = rightBoundary.transform.position.x;
        transform.position = tempPos;
    }
    IEnumerator TeleportLeft()
    {
        yield return new WaitForSeconds(1f);
        tempPos.x = leftBoundary.transform.position.x;
        transform.position = tempPos;
    }
    void BossFightTeleportRight()
    {
        tempPos.x = rightBoundary.transform.position.x;
        transform.position = tempPos;
    }
    void BossFightTeleportLeft()
    {
        tempPos.x = leftBoundary.transform.position.x;
        transform.position = tempPos;
    }
}
