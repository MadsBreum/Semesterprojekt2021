using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D Rb = new Rigidbody2D();
    public BoxCollider2D Cc = new BoxCollider2D();
    public bool touchingGround;
    float maxVel = 5;
    void Start()
    {
        Rb.GetComponent<Rigidbody2D>();
        Cc.GetComponent<BoxCollider2D>();
        Rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && touchingGround)
        {
            Rb.AddForce(transform.up * 210f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Rb.AddForce(transform.right * -10f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Rb.AddForce(transform.right * 10f);
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
        if (collision.gameObject.tag == "Platform" && collision.otherCollider == Cc)
        {
            touchingGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && collision.otherCollider == Cc)
            touchingGround = true;
    }

}