using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 20f;
    public float impactForce = 50f;

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
        if (!collider.gameObject.CompareTag("Player") && !collider.gameObject.CompareTag("Platform") && !collider.gameObject.CompareTag("Untagged") && !collider.gameObject.CompareTag("Abililty") && !collider.gameObject.CompareTag("Border"))
        {
            Debug.Log("Projectile hit " + collider.name);
            // Find the PlayerHealth component and apply damage
            collider.GetComponent<PlayerHealth>().TakeDamage(damage);

            Rigidbody2D targetRigidbody = collider.GetComponent<Rigidbody2D>();

            targetRigidbody.AddForce(transform.right * impactForce, ForceMode2D.Impulse);

            Destroy(gameObject);
        }
    }
}
