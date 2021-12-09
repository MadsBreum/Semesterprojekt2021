using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDamage : MonoBehaviour
{
    float damage;
    float stunTime;

    //bool dealtDamage;

    // Start is called before the first frame update
    void Awake()
    {
        // Get the damage amount from the parent
        damage = GetComponentInParent<IceSpikes>().damage;

        stunTime = GetComponentInParent<IceSpikes>().stunTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Get the dealtDamage bool from parent
        bool dealtDamage = GetComponentInParent<IceSpikes>().dealtDamage;

        // See if it hits player2
        if (!collider.gameObject.CompareTag("Player2") && !collider.gameObject.CompareTag("Platform") && !collider.gameObject.CompareTag("Untagged") && !collider.gameObject.CompareTag("Ability") && !collider.gameObject.CompareTag("Border"))
        {
            if (dealtDamage == false)
            {
                Debug.Log("IceSpikes hit " + collider.name);
                // Find the PlayerHealth component and apply damage
                collider.GetComponent<PlayerHealth>().TakeDamage(damage);

                collider.GetComponent<PlayerMovementController>().StartCoroutine("Stunned", stunTime);

                GetComponentInParent<IceSpikes>().DealtDamage();
            }
        }
    }
}
