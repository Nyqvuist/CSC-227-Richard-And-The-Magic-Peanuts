using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage the projectile inflicts

    // Called when the projectile collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player GameObject
            Health playerHealth = collision.gameObject.GetComponent<Health>();

            // If the player has a PlayerHealth component, deal damage to the player
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // Destroy the projectile after it hits the player
            Destroy(gameObject);
        }
    }
}
