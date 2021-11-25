using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShard : MonoBehaviour
{
    public float speed = 25f;
    public float damage = 10f;
    public float impactForce = 15f;
    //public float slowDown = 0.5f;
    public float slowDownTime = 1f;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
            return;
        }
        // See if it hits player2
        if (!collider.gameObject.CompareTag("Player2") && !collider.gameObject.CompareTag("Platform") && !collider.gameObject.CompareTag("Untagged"))
        {
            Debug.Log("IceShard hit " + collider.tag);
            // Find the PlayerHealth component and apply damage
            collider.GetComponent<PlayerHealth>().TakeDamage(damage);

            collider.GetComponent<PlayerMovementController>().StartCoroutine("Slowdown", slowDownTime);

            Rigidbody2D targetRigidbody = collider.GetComponent<Rigidbody2D>();

            targetRigidbody.AddForce(transform.right * impactForce, ForceMode2D.Impulse);

            Destroy(gameObject);
        }
    }
}
