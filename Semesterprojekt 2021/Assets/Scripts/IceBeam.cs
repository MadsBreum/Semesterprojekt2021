using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBeam : MonoBehaviour
{
    public float stunTime = 2.5f;
    public float damage = 40f;
    public float timeActive = 1.5f;
    public float timeChargeUp = 0.5f;

    public bool dealtDamage;

    public BoxCollider2D bc2d;

    // Start is called before the first frame update

    void OnEnable()
    {
        dealtDamage = false;
        StartCoroutine("IceBeamActiveTime");
    }

    IEnumerator IceBeamActiveTime()
    {
        bc2d.enabled = false;

        yield return new WaitForSeconds(timeChargeUp);

        bc2d.enabled = true;

        yield return new WaitForSeconds(timeActive);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // See if it hits player2
        if (!collider.gameObject.CompareTag("Player2") && !collider.gameObject.CompareTag("Platform") && !collider.gameObject.CompareTag("Untagged") && !collider.gameObject.CompareTag("Ability") && !collider.gameObject.CompareTag("Border") && !collider.gameObject.CompareTag("UltimatePoint"))
        {
            if (dealtDamage == false)
            {
                //Debug.Log("IceSpikes hit " + collider.name);
                // Find the PlayerHealth component and apply damage
                collider.GetComponent<PlayerHealth>().TakeDamage(damage);
                dealtDamage = true;

                collider.GetComponent<PlayerMovementController>().StartCoroutine("Stunned", stunTime);
            }
        }
    }
}
