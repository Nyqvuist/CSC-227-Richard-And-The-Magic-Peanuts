using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5f;
    private GameObject player;

    void Start()
    {
        // Find the player object by tag
        player = GameObject.FindGameObjectWithTag("Richard");

        if (player == null)
        {
            Debug.LogError("Player not found.");
        }
    }

    void Update()
    {
        // If player is found, move towards the player
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collided with player
        if (collision.CompareTag("Richard"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}