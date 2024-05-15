using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueITScript : MonoBehaviour
{
    public float attackRange = 3f;
    public float moveSpeed = 10f;
    public GameObject laserPrefab;
    public float laserCooldown = 2f; // Cooldown time between each shot
    private float nextFireTime = 0f;

    private Transform player;
    private bool isPlayerInRange;
    private Animator animator;

    void Start()
    {
        // Find the player object by tag
        player = GameObject.FindGameObjectWithTag("Richard").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if player is in range
        float distanceToPlayer = Mathf.Abs(transform.position.x - player.position.x);
        if (distanceToPlayer <= attackRange)
        {
            isPlayerInRange = true;
        }
        else
        {
            isPlayerInRange = false;
        }

        // If player is in range and not already attacked within the cooldown time, attack
        if (isPlayerInRange && Time.time >= nextFireTime)
        {
            AttackPlayer();
        }
        else
        {
            // If player is not in range, move towards player
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        // Move towards the player's horizontal position
        float direction = Mathf.Sign(player.position.x - transform.position.x);
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        // Flip the enemy sprite if moving in the opposite direction
        if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void AttackPlayer()
    {
        // Play attack animation
        animator.SetTrigger("isAttacking");

        // Shoot the laser towards the player with some randomness in direction
        Vector3 direction = (player.position - transform.position).normalized;
        direction += Random.insideUnitSphere * 0.2f; // Add some randomness to direction
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = direction * 10f; // Adjust the speed as needed

        // Set the next fire time after cooldown
        nextFireTime = Time.time + laserCooldown;
    }
}