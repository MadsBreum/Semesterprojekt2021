using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBeam : MonoBehaviour
{
    public float stunTime = 2.5f;
    public float damage = 40f;
    public float timeActive = 1.5f;

    public bool dealtDamage;

    // Start is called before the first frame update
    void OnEnable()
    {
        dealtDamage = false;
        StartCoroutine("IceBeamActiveTime");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IceBeamActiveTime()
    {
        yield return new WaitForSeconds(timeActive);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // See if it hits player2
        if (!collider.gameObject.CompareTag("Player2") && !collider.gameObject.CompareTag("Platform"))
        {
            if (dealtDamage == false)
            {
                Debug.Log("IceSpikes hit " + collider.name);
                // Find the PlayerHealth component and apply damage
                collider.GetComponent<PlayerHealth>().TakeDamage(damage);
                dealtDamage = true;

                collider.GetComponent<PlayerMovementController>().StartCoroutine("Stunned", stunTime);
            }
        }
    }
}
