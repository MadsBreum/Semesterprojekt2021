using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour
{
    public float timeActive = 2.5f;
    public float damage = 30f;
    public float impactForce = 50f;
    public float nukeSize = 10f;

    bool dealtDamage;

    // Start is called before the first frame update
    void Start()
    {
        dealtDamage = false;
        StartCoroutine("FireNukeActiveTime");

        gameObject.transform.localScale = new Vector3(nukeSize, nukeSize, nukeSize);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // See if it hits player2
        if (!collider.gameObject.CompareTag("Player") && !collider.gameObject.CompareTag("Platform") && !collider.gameObject.CompareTag("Untagged") && !collider.gameObject.CompareTag("Ability") && !collider.gameObject.CompareTag("Border") && !collider.gameObject.CompareTag("UltimatePoint"))
        {
            if (dealtDamage == false)
            {
                Debug.Log("Projectile hit " + collider.name);
                // Find the PlayerHealth component and apply damage
                collider.GetComponent<PlayerHealth>().TakeDamage(damage);

                dealtDamage = true;
                // Get the Rigidbody and apply force to push the target away
                Rigidbody2D targetRigidbody = collider.GetComponent<Rigidbody2D>();

                Vector2 dir = targetRigidbody.transform.position - transform.position;
                dir = dir.normalized;

                targetRigidbody.AddForce(dir * impactForce, ForceMode2D.Impulse);
            }
        }
    }

    IEnumerator FireNukeActiveTime()
    {
        yield return new WaitForSeconds(timeActive);

        Destroy(gameObject);
    }
}
