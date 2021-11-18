using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D Rb = new Rigidbody2D();
    public BoxCollider2D Bc = new BoxCollider2D();
    public bool touchingGround;
    public float maxVel = 5;
    public float jump = 210;
    public float speed = 10;
    void Start()
    {
        Rb.GetComponent<Rigidbody2D>();
        Bc.GetComponent<BoxCollider2D>();
        Rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) && touchingGround)
        {
            Rb.AddForce(transform.up * jump);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rb.AddForce(transform.right * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rb.AddForce(transform.right * speed);
        }
        if (Rb.velocity.x > maxVel)
        {
            Rb.velocity = new Vector2(maxVel, Rb.velocity.y);
        } else if (Rb.velocity.x < -maxVel)
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

}
