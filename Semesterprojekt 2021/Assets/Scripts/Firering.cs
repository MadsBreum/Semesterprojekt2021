using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firering : MonoBehaviour
{
    public float timeActive = 1f;
    public float damage = 30f;
    public float impactForce = 50f;
    bool dealtDamage;

    private void OnEnable()
    {
        dealtDamage = false;
        StartCoroutine("FireringActiveTime");
    }
    // Start is called before the first frame update
    void Start()
    {

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
            if (dealtDamage == false)
            {
                Debug.Log("Projectile hit " + collider.name);
                // Find the PlayerHealth component and apply damage
                collider.GetComponent<PlayerHealth>().TakeDamage(damage);

                dealtDamage = true;

                Rigidbody2D targetRigidbody = collider.GetComponent<Rigidbody2D>();

                targetRigidbody.AddForce(transform.right * impactForce);
            }
            
        }
    }

    IEnumerator FireringActiveTime()
    {
        yield return new WaitForSeconds(timeActive);

        gameObject.SetActive(false);
    }
}
