using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float p_StartingHealth = 100f;

    public string playerNumber = "Player";

    public float p_CurrentHealth;

    public bool canUseAbility = true;

    private void OnEnable()
    {
        // When the player is enabled, reset the player's health and set dead to false
        p_CurrentHealth = p_StartingHealth;

        //Debug.Log(gameObject.name + "'s starting health is " + p_StartingHealth);
    }

    public void TakeDamage(float damage)
    {
        // Subtract damage from current health
        p_CurrentHealth -= damage;
        //Debug.Log(gameObject.name + " lost " + damage + " health!");

        // If current health goes to zero or below, run OnDeath
        if (p_CurrentHealth <= 0)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        // turn off the GameObject

        gameObject.SetActive(false);

        Debug.Log(gameObject.name + " died");
    }
}
