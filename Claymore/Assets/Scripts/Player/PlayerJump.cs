using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;       // The force of the jump
    public float groundCheckRadius = 0.2f;  // The radius of the circle used to check if the player is on the ground
    public Transform groundCheck;       // The position of the object used to check if the player is on the ground
    public LayerMask groundLayer;      // The layer mask used to determine what counts as ground
    public Animator animator;          // The Animator component of the player
    private Rigidbody2D player;

    private bool isGrounded;            // Whether or not the player is on the ground
    [SerializeField] float jumpDelay = 0.2f;

    private bool isGroundedLastFrame; //

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        isGrounded = collider != null;

        Debug.Log(collider == null ? "null" : collider.name);

        if (isGrounded != isGroundedLastFrame) 
        {
        animator.SetBool("Grounded", isGrounded);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
            Debug.Log("Jump");
            animator.SetBool("StartJump", true);
            Invoke(nameof(JumpStartEnd), jumpDelay);
        }

        isGroundedLastFrame = isGrounded;
    }

    void JumpStartEnd()
    {
        animator.SetBool("StartJump", false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}