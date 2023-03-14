using UnityEngine;

class PlatformerPlayer : MonoBehaviour
{
    [SerializeField, HideInInspector] Rigidbody2D rb;
    [SerializeField] float speed = 5;
    public Vector3 forceDirection = Vector3.back;
    public float forceMagnitude = 100f;


    float horizontalMove = 0f;
    public Animator animator;

    private SpriteRenderer spriteRenderer;
    public Transform childObject;

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
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));

        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
            if (childObject != null)
            {
                childObject.localScale = new Vector3(-1, 1, 1);
            }
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
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

        rb.velocity = velocity;
    }
}
