using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public float delayBeforeDeletingPlayer = 15f; // Time to wait before deleting the player

    private Transform player;
    private bool hasDeletedPlayer = false;
    private float startTime;

    void Start()
    {
        // Find the player object by tag
        player = GameObject.FindGameObjectWithTag("Richard").transform;

        if (player != null)
        {
            Debug.Log("Player found. Starting delay before deleting player.");
            // Record the start time
            startTime = Time.time;
        }
        else
        {
            Debug.LogError("Player not found. Ensure that the player object is tagged as 'Richard'.");
        }
    }

    void Update()
    {
    }
}