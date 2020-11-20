using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    //public Rigidbody2D rb;
    public Transform movePoint;
    public Animator animator;
    Vector2 movement;

    // Update is called once per frame

    void Start()
    {
        movePoint.parent = null;
    }
    void Update()
    {
 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {

            if (Mathf.Abs(movement.x) == 1f)
            {
                movePoint.position += new Vector3(movement.x, 0f, 0f);
            }

            if (Mathf.Abs(movement.y) == 1f)
            {
                movePoint.position += new Vector3(0f, movement.y, 0f);
            }

        }

        if(movement.x > 0)
        {
            animator.SetFloat("LastFacedRight", 1);
        }
        else if(movement.x < 0)
        {
            animator.SetFloat("LastFacedRight", 0);
        }
        animator.SetFloat("Speed", movement.magnitude);

    }

    void FixedUpdate()
    {
        // Movement
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
