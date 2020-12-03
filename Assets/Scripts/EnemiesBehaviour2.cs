using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehaviour2 : MonoBehaviour
{
    public float speed;
    public bool MoveRight;

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        // Makes the enemy switch directions instead of teleporting when reaching screen boundaries 
        if (trig.gameObject.CompareTag("rightWall") || trig.gameObject.CompareTag("leftWall"))
        {

            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }
}
