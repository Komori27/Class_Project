using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    [SerializeField] float retreatDistance = 2f;
    public Transform pointA;
    public Transform pointB;
    public Transform player;
    public LayerMask playerLayer;
    public Transform bossTransform;

    private bool isMovingForward = true;
    private float distanceToPlayer;
    [SerializeField] Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if player is in range
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < retreatDistance)
        {
            // Move away from player
            MoveAwayFromPlayer();
        }
        else
        {
            // Move back and forth between point A and B
            if (isMovingForward)
            {
                transform.position = Vector2.MoveTowards(transform.position, pointA.position, moveSpeed * Time.deltaTime);
                anim.SetFloat("moveSpeed", Mathf.Abs(moveSpeed));
                if (transform.position == pointA.position)
                {
                    isMovingForward = false;
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, pointB.position, moveSpeed * Time.deltaTime);
                anim.SetFloat("moveSpeed", -Mathf.Abs(moveSpeed));
                if (transform.position == pointB.position)
                {
                    isMovingForward = true;
                }
            }
        }
    }

    void MoveAwayFromPlayer()
    {
        // Find the direction away from the player
        Vector2 direction = ((Vector2)transform.position - (Vector2)player.position).normalized;

        // Calculate the target position to move towards
        Vector2 targetPosition = (Vector2)transform.position + direction * retreatDistance;

        // Move towards the target position using rigidbody2D.MovePosition
        GetComponent<Rigidbody2D>().MovePosition(targetPosition);

        // Set the moveSpeed parameter to 0 to stop the walk animation
        anim.SetFloat("moveSpeed", 0f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(bossTransform.position, retreatDistance);
    }
}


