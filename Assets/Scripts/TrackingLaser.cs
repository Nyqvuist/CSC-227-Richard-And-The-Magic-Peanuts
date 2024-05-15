using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingLaser : MonoBehaviour
{
    private Transform target;
    private float speed;

    public void SetTarget(Transform newTarget, float newSpeed)
    {
        target = newTarget;
        speed = newSpeed;
    }

    void Update()
    {
        if (target != null)
        {
            // Move towards the player's position
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            // If the target is lost (e.g., player is destroyed), destroy the laser
            Destroy(gameObject);
        }
    }
}