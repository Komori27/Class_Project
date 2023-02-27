using UnityEngine;

public class GhoulHitscan : MonoBehaviour
{
    public float attackDistance = 2f;  // The distance at which the enemy will attack the player
    public float attackDamage = 10f;   // The amount of damage the enemy will deal to the player
    public float moveSpeed = 5f;       // The speed at which the enemy moves towards the player

    Rigidbody2D rb;
    public Transform player;             // The transform of the player
    public Animator animator;             // The animator component attached to the enemy
    private bool isAttacking = false;  // Whether or not the enemy is currently attacking the player

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If the player is within attacking distance, and the enemy isn't already attacking
        if (distanceToPlayer <= attackDistance && !isAttacking)
        {
            // Start attacking the player
            isAttacking = true;
            animator.SetTrigger("Attack");
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
        }
        // Otherwise, if the player is outside of attacking distance
        else if (distanceToPlayer > attackDistance)
        {
            // Stop attacking the player
            isAttacking = false;

            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }

    public void AttackPlayer()
    {
        // Deal damage to the player
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }

}
