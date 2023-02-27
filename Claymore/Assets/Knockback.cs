using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float knockbackTime = 0.5f;
    public string hurtAnimParam = "Hurt";

    private Animator anim;
    private Rigidbody2D rb;
    private bool isKnockedBack;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.Log("rb Null");
        }
        if (anim == null)
        {
            Debug.Log("anim Null");
        }
    }

    private void Update()
    {
        if (isKnockedBack)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeKnockback(Vector2 direction)
    {
        if (!isKnockedBack)
        {
            rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
            isKnockedBack = true;
            anim.SetTrigger(hurtAnimParam);
            Invoke(nameof(ResetKnockback), knockbackTime);
        }
    }

    private void ResetKnockback()
    {
        isKnockedBack = false;
    }
}
