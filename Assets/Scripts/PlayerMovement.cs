using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : LevelLoader
{
    private float Dead = 0f;
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Animator animator;
    public Vector2 movement;
    public LayerMask enemies;
    public float delay = 0f;
    public SpriteRenderer rPlayer;
    public LayerMask whatStopsMovement;
    public static Vector3 origin;
    public static int Skin;

    // Update is called once per frame

    void Start()
    {
        Dead = 0f;

        movePoint.parent = null;
    }
    void Update()
    {
        animator.SetInteger("Skin", Skin);

        origin = transform.position;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
       
        if(Vector3.Distance(transform.position, movePoint.position) <= .05f && Dead == 0f)
        {

            if (Mathf.Abs(movement.x) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(movement.x, 0f, 0f);
                }
            }   else if (Mathf.Abs(movement.y) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, movement.y, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, movement.y, 0f);
                }
                else Debug.Log("Bonk");
            }

            if (Physics2D.OverlapCircle(movePoint.position, .01f, enemies) && delay == 0f)
            {
                Debug.Log("You hit an enemy");
                Dead = 1f;
                ReloadLevel();
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
}
