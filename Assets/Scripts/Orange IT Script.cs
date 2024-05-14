using UnityEngine;

public class EnemyAI2D : MonoBehaviour
{
    public float attackRange = 3f;
    public float moveSpeed = 5f;

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
            AttackPlayer();
        }
        else
        {
            isPlayerInRange = false;
        }

        // Update animator parameters based on movement
        animator.SetBool("isWalking", !isPlayerInRange);
        animator.SetBool("isIdle", isPlayerInRange);

        // If player is not in range, move towards player
        if (!isPlayerInRange)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        // Move towards the player's horizontal position
        float direction = Mathf.Sign(player.position.x - transform.position.x);
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        // Implement attack behavior here, such as reducing player health
        Debug.Log("Attacking Player!");
    }

}
