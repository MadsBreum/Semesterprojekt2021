using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float p_StartingHealth = 100f;
    private float p_CurrentHealth;
    private bool p_Dead;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        // When the player is enabled, reset the player's health and set dead to false
        p_CurrentHealth = p_StartingHealth;
        p_Dead = false;

        Debug.Log(gameObject.name + "'s starting health is " + p_StartingHealth);
    }

    public void TakeDamage(float damage)
    {
        // Subtract damage from current health
        p_CurrentHealth -= damage;
        Debug.Log(gameObject.name + " lost " + damage + " health!");

        // If current health goes to zero or below, run OnDeath
        if (p_CurrentHealth <= 0)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        // Set p_Dead to true and turn off the GameObject
        p_Dead = true;

        gameObject.SetActive(false);

        Debug.Log(gameObject.name + " died");
    }
}
