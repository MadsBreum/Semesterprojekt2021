using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 20f;
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
        // See if it hits player2
        if (collider.gameObject.CompareTag("Player2"))
        {
            Debug.Log("Projectile hit " + collider.name);
            // Find the PlayerHealth component and apply damage
            collider.GetComponent<PlayerHealth>().TakeDamage(damage);

            Destroy(gameObject);
        }
        if (collider.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
