using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float moveInput = 0;
    public float speed = 25;
    public float speedMax = 10;
    public float jumpForce = 10;
    public bool isGrounded = false;
    bool jump = false;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (movingRight == false)
            {
                Flip();
            }
            movingRight = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (movingRight == true)
            {
                Flip();
            }
            movingRight = false;
        }

        RaycastHit2D hit = Physics2D.Linecast(transform.position, groundCheck.transform.position, groundLayer);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * moveInput * speed);

        if (Mathf.Abs(rb.velocity.x) < speedMax)
            rb.AddForce(Vector2.right * moveInput * speed);

        if (jump)
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            jump = false;
        }
    }

    private void Flip()
    {
        transform.Rotate(new Vector3(0f, 180f, 0f));

        
    }
}
