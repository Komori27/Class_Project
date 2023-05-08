using JetBrains.Annotations;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 5;
    [SerializeField] float forceMagnitude = 100f;

    public Vector3 currentPosition;
    private PlayerData playerData;

    [SerializeField] Stamina stamina;
    [SerializeField] PlayerStaminaHUD staminaBar;
    public bool isDodging = false;


    [SerializeField] Dodge dodge;
    public Animator animator;
    public Transform childObject;

    private SpriteRenderer spriteRenderer;
    private float horizontalMove = 0f;

    void Start()
    {
        currentPosition = transform.position;
        float[] positionArray = new float[] { currentPosition.x, currentPosition.y};
        playerData = new PlayerData(this);


        spriteRenderer = GetComponent<SpriteRenderer>();
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        staminaBar.SetStamina(stamina.currentStamina);
        {
            if (Input.GetKeyDown(KeyCode.G) && !dodge.IsDodging)
            {
                stamina.UseStamina(50);
                isDodging = true;
                float horizontalD = Input.GetAxis("Horizontal");
                animator.SetTrigger("IsDodging");
                if (horizontalD < 0)
                {
                    dodge.DodgeDirection(-1);
                }
                else if (horizontalD > 0)
                {
                    dodge.DodgeDirection(1);
                }
                else
                {
                    dodge.DodgeDirection(0);
                }
            }
        }




        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
            if (childObject != null)
            {
                childObject.localScale = new Vector3(-1, 1, 1);
            }
        }
        else if (horizontalMove > 0)
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
    void endDodge()
    {
        isDodging = false;
    }
}
