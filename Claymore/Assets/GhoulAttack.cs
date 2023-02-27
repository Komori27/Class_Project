using System.Collections;
using UnityEngine;

public class GhoulAttack : MonoBehaviour
{
    public float attackDistance = 2f;  // The distance at which the enemy will attack the player
    public float attackDamage = 10f;   // The amount of damage the enemy will deal to the player
    public float moveSpeed = 5f;       // The speed at which the enemy moves towards the player

    private Transform playerTransform; // The transform of the player
    private bool isAttacking = false;  // Whether or not the enemy is currently attacking the player

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // If the player is within attacking distance, and the enemy isn't already attacking
        if (distanceToPlayer <= attackDistance && !isAttacking)
        {
            // Start attacking the player
            isAttacking = true;
            StartCoroutine(AttackPlayer());
        }
        // Otherwise, if the player is outside of attacking distance
        else if (distanceToPlayer > attackDistance)
        {
            // Stop attacking the player
            isAttacking = false;
        }

        // If the enemy is currently attacking the player
        if (isAttacking)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }
    }

    IEnumerator AttackPlayer()
    {
        // While the enemy is attacking the player
        while (isAttacking)
        {
            // Deal damage to the player
            playerTransform.GetComponent<PlayerHealth>().TakeDamage(attackDamage);

            // Wait for a short amount of time before attacking again
            yield return new WaitForSeconds(1f);
        }
    }
}
