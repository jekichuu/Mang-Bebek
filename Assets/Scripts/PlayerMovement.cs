using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float healthBar = 3f;
    public float moveSpeed = 5f;
    //public Rigidbody2D rb;
    public Transform movePoint;
    public Animator animator;
    public Vector2 movement;
    public LayerMask enemies;
    public Image Health1, Health2, Health3;
    public float delay = 0f;
    public SpriteRenderer rPlayer;
    private float damaged = 0f;
    public LayerMask whatStopsMovement;

    // Update is called once per frame

    void Start()
    {
        movePoint.parent = null;
    }
    void Update()
    {
 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (delay > 0f)
        {
            delay--;
            damaged = 0f;
        }
        else if (delay == 0f) AnimationBickering();

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
       
        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
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

            if (Physics2D.OverlapCircle(movePoint.position, .001f, enemies) && delay == 0f)
            {
                if (healthBar == 3)
                {
                    Color newColor = Health3.color;
                    newColor.a = 0;
                    Health3.color = newColor;
                }
                else if (healthBar == 2)
                {
                    Color newColor = Health2.color;
                    newColor.a = 0;
                    Health2.color = newColor;
                }
                else if (healthBar == 1)
                {
                    Color newColor = Health1.color;
                    newColor.a = 0;
                    Health1.color = newColor;
                }
                healthBar -= 1;
                damaged = 1f;
                AnimationBickering();
                delay = 100f;
                Debug.Log("You hit an enemy");
                if (healthBar == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
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

    void AnimationBickering()
    {
        Color Aph = rPlayer.material.color;
        if (damaged == 1f)
        {
            Aph.a = 0.5f;
            rPlayer.material.color = Aph;
        }
        if (damaged == 0f)
        {
            Aph.a = 1f;
            rPlayer.material.color = Aph;
        }
    }
    void FixedUpdate()
    {

    }
}
