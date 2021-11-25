using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDamage : MonoBehaviour
{
    public float stunTime = 2f;
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
        // Get the damage amount from the parent
        float damage = GetComponentInParent<IceSpikes>().damage;
        // Get the dealtDamage bool from parent
        bool dealtDamage = GetComponentInParent<IceSpikes>().dealtDamage;

        // See if it hits player2
        if (collider.gameObject.CompareTag("Player2"))
        {
            if (dealtDamage == false)
            {
                Debug.Log("IceSpikes hit " + collider.name);
                // Find the PlayerHealth component and apply damage
                collider.GetComponent<PlayerHealth>().TakeDamage(damage);

                collider.GetComponent<PlayerMovementController>().StartCoroutine("Stunned", stunTime);

                collider.GetComponent<UseAbility>().StartCoroutine("Stunned", stunTime);

                GetComponentInParent<IceSpikes>().DealtDamage();
            }
        }
    }
}
