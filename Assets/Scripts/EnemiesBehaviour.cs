using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehaviour : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    private GameObject rightBoundary;
    private GameObject leftBoundary;
    private Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        tempPos = transform.position;
        rightBoundary = GameObject.FindGameObjectWithTag("rightWall");
        leftBoundary = GameObject.FindGameObjectWithTag("leftWall");
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            //transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            //transform.localScale = new Vector2(-1, 1);
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
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
}
