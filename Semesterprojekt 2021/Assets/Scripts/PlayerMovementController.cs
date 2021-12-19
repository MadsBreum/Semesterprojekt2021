using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D Rb = new Rigidbody2D();
    public BoxCollider2D Bc = new BoxCollider2D();

    public bool touchingGround;
    public float maxVel = 45;
    public float currentVel;
    public float jump = 210;
    public float currentJump;
    public float speed = 60;
    public float slowDown = 0.5f;

    float moveInput = 0;
    float jumpInput = 0;

    bool movingRight = true;

    public bool canMove = true;

    public string playerNumber;

    private Animator animator;

    private void OnEnable()
    {
        currentVel = maxVel;
        currentJump = jump;

        Rb.drag = 6;
        Rb.gravityScale = 6;
    }

    void Start()
    {
        Rb.GetComponent<Rigidbody2D>();
        Bc.GetComponent<BoxCollider2D>();
        Rb.freezeRotation = true;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw(playerNumber + "Horizontal");

        jumpInput = Input.GetAxisRaw(playerNumber + "Vertical");

        if (canMove == true)
        {
            if (moveInput == 1)
            {
                if (movingRight == false)
                {
                    Flip();
                }
                movingRight = true;

                animator.SetBool("Walking", true);
            }

            else if (moveInput == -1)
            {
                if (movingRight == true)
                {
                    Flip();
                }
                movingRight = false;

                animator.SetBool("Walking", true);
            }
            
            else
            {
                animator.SetBool("Walking", false);
            }

            if (!touchingGround)
            {
                animator.SetBool("Jumping", true);
            }
            else if (touchingGround)
            {
                animator.SetBool("Jumping", false);
            }
        }

        /*
        if (canMove && touchingGround && moveInput == 1 || moveInput == -1)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        */
    }

    void FixedUpdate()
    {
        if (canMove == true)
        {
            Rb.AddForce(Vector2.right * moveInput * speed);

            if (jumpInput == 1 && touchingGround)
            {
                Rb.AddForce(transform.up * currentJump, ForceMode2D.Impulse);
            }
            /*
            if (Input.GetKey(KeyCode.UpArrow) && touchingGround)
            {
                Rb.AddForce(transform.up * currentJump, ForceMode2D.Impulse);
            }
            */
            /*
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Rb.AddForce(transform.right * speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Rb.AddForce(transform.right * speed);
            }
            */
            if (Rb.velocity.x > currentVel)
            {
                Rb.velocity = new Vector2(currentVel, Rb.velocity.y);
            }
            else if (Rb.velocity.x < -currentVel)
            {
                Rb.velocity = new Vector2(-currentVel, Rb.velocity.y);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && collision.otherCollider == Bc)
        {
            touchingGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && collision.otherCollider == Bc)
            touchingGround = true;
    }

    private void Flip()
    {
        transform.Rotate(new Vector3(0f, 180f, 0f));
    }

    // Stop the player from being able to move for a specific time
    public IEnumerator Stunned(float stunTime)
    {
        canMove = false;
        //Debug.Log("Stunned for " + stunTime + " seconds");

        yield return new WaitForSeconds(stunTime);

        canMove = true;
        //Debug.Log("Not stunned anymore");
    }

    public IEnumerator Slowdown(float slowDownTime)
    {
        currentVel = maxVel * slowDown;
        currentJump = jump * slowDown;

        Rb.drag *= slowDown;
        Rb.gravityScale *= slowDown;

        //Rb.velocity *= slowDown;
      //  Debug.Log("Slowed for " + slowDownTime + " seconds");

        yield return new WaitForSeconds(slowDownTime);

        currentVel = maxVel;
        currentJump = jump;

        Rb.drag = 6;
        Rb.gravityScale = 6;

       // Debug.Log("Not slowed anymore");
    }
}
