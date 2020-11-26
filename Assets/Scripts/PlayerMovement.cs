using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : LevelLoader
{
    // Referencing GameObjects
    public SpriteRenderer rPlayer;
    public Animator animator;
    public Transform movePoint; // Move point is for referencing where the player will move to (Required for grid movement)
    public GameObject ClearUI;

    // Variable to take chosen skin index from SkinPicker.cs
    public static int Skin;

    // Variables for movements
    public Vector2 movement;
    public static Vector3 origin;
    public float moveSpeed = 5f;

    // Referencing Layers for certain uses
    public LayerMask enemies, whatStopsMovement, goal;

    // Variable to indicate pause or stopped condition
    private bool gameStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        // Reset gameStopped value for after death
        gameStopped = false;

        // Removes movePoint GameObject from being "Player's" child
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

        // Sets the skin of the player
        animator.SetInteger("Skin", Skin);

        // Key mapping for player movements
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        // Moves the move point according to input
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
       
        // Checks to see wheter the player is moving and if the game is not stopped
        if(Vector3.Distance(transform.position, movePoint.position) <= .05f && !gameStopped)
        {
            // Making if and else if statements for x and y movement so that they can't move diagonally
            if (Mathf.Abs(movement.x) == 1f)
            {
                // Checks whether the move point is going to collide with an object or not for x axis
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0f, 0f), .2f, whatStopsMovement))
                {
                    // Moving the move point to the next position if cleared
                    movePoint.position += new Vector3(movement.x, 0f, 0f);
                }
            }   
            else if (Mathf.Abs(movement.y) == 1f)
            {
                // Checks whether the move point is going to collide with an object or not for y axis
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, movement.y, 0f), .2f, whatStopsMovement))
                {
                    // Moving the move point to the next position if cleared
                    movePoint.position += new Vector3(0f, movement.y, 0f);
                }
            }

            // Checks to see if the player will collide with an enemy
            if (Physics2D.OverlapCircle(movePoint.position, .01f, enemies))
            {
                // Stops the game to disable player movement and reloads the scene
                gameStopped = true;
                ReloadLevel();
            }

            // Checks to see if the player will be going into the goal
            if (Physics2D.OverlapCircle(movePoint.position, .2f, goal))
            {
                // Stops the game to disable player movement and opens level cleared UI
                gameStopped = true;
                ClearUI.SetActive(true);
            }
        }

        // Idle animation adjustor variable to decide whether to face left or right based on last movements
        if(movement.x > 0)
        {
            animator.SetFloat("LastFacedRight", 1);
        }
        else if(movement.x < 0)
        {
            animator.SetFloat("LastFacedRight", 0);
        }
        // Sets the speed value to activate/deactivate moving animation
        animator.SetFloat("Speed", movement.magnitude);

    }
}
