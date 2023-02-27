using UnityEngine;

class PlatformerPlayer : MonoBehaviour
{
    [SerializeField, HideInInspector] Rigidbody2D rb;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpSpeed = 5;
    [SerializeField] int airJumpCount = 1;
    float horizontalMove = 0f;
    public Animator animator;

    [SerializeField] Vector2 foot = Vector2.down;
    [SerializeField] float footRadius = 0.15f;
    private SpriteRenderer spriteRenderer;
    public Transform childObject;

    bool grounded = false;
    int currentAirJumpBudget = 0;

    bool jumpInput = false;

    void OnValidate()
    {
        // Get the sprite renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (grounded || currentAirJumpBudget > 0)
        {
            bool jump = Input.GetKeyDown(KeyCode.Space);

            if (jump)
            {
                this.jumpInput = true;
            }
        }
        // Get the horizontal input axis (left/right arrow keys or A/D keys)
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Move the character in the horizontal direction
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));

        // Flip the character sprite if moving left
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
            // Flip the child object to face the other way
            if (childObject != null)
            {
                childObject.localScale = new Vector3(-1, 1, 1);
            }
        }
        // Flip the character sprite back if moving right
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
            // Flip the child object back to face the original direction
            if (childObject != null)
            {
                childObject.localScale = new Vector3(1, 1, 1);
            }
        }
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        horizontal *= speed;

        Vector2 velocity = rb.velocity;

        velocity.x = horizontal;

        if (grounded || currentAirJumpBudget > 0)
        {
            if (jumpInput)
            {
                velocity.y = jumpSpeed;

                if (!grounded)
                    currentAirJumpBudget--;
                jumpInput = false;
            }
        }

        rb.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Vector2 vel = collision.contacts[0].relativeVelocity;
        // if (vel.y > 0) return;

        Vector3 globalFooPoint = transform.TransformPoint(foot);
        bool isAnyPontInFootArea = false;
        foreach (var contact in collision.contacts)
        {
            float distance = Vector3.Distance(contact.point, globalFooPoint);
            bool isInFootArea = distance <= footRadius;
            if (isInFootArea)
            {
                isAnyPontInFootArea = true;
                break;
            }
        }

        if (!isAnyPontInFootArea)
            return;

        grounded = true;
        currentAirJumpBudget = airJumpCount;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

    public void RefillAirJump()
    {
        currentAirJumpBudget = airJumpCount;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 globalP = transform.TransformPoint(foot);
        Gizmos.DrawWireSphere(globalP, footRadius);
    }
}
