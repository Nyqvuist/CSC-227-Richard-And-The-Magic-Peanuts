using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the player
    public int currentHealth; // Current health of the player

    private void Start()
    {
        // Initialize current health to max health at the start of the game
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Reduce player's health by the damage amount
        currentHealth -= damage;

        // Check if the player has died
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Perform actions for player death, such as displaying a game over screen or resetting the level
        Debug.Log("Player has died!");
        // For demonstration purposes, you might want to reload the current scene or perform other actions.
    }
}
