using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D Rb = new Rigidbody2D();
    public BoxCollider2D Bc = new BoxCollider2D();
    public bool touchingGround;
    public float maxVel = 5;
    public float jump = 210;
    public float speed = 10;
    bool movingRight = true;

    void Start()
    {
        Rb.GetComponent<Rigidbody2D>();
        Bc.GetComponent<BoxCollider2D>();
        Rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (movingRight == false)
            {
                Flip();
            }
            movingRight = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (movingRight == true)
            {
                Flip();
            }
            movingRight = false;
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && touchingGround)
        {
            Rb.AddForce(transform.up * jump);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Rb.AddForce(transform.right * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Rb.AddForce(transform.right * speed);
        }
        if (Rb.velocity.x > maxVel)
        {
            Rb.velocity = new Vector2(maxVel, Rb.velocity.y);
        }
        else if (Rb.velocity.x < -maxVel)
        {
            Rb.velocity = new Vector2(-maxVel, Rb.velocity.y);
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
}
