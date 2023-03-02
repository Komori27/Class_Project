using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;       // The force of the jump
    public float groundCheckRadius = 0.2f;  // The radius of the circle used to check if the player is on the ground
    public Transform groundCheck;       // The position of the object used to check if the player is on the ground
    public LayerMask whatIsGround;      // The layer mask used to determine what counts as ground
    public Animator animator;          // The Animator component of the player

    private bool isGrounded;            // Whether or not the player is on the ground



    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // If the player is on the ground and the jump button is pressed, jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
            isGrounded = false;
            animator.SetBool("OnLand", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
        }

        if (isGrounded)
        {
            isGrounded = true;
            animator.SetBool("OnLand", true);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
