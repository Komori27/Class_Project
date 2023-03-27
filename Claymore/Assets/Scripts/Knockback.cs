using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float knockbackTime = 0.5f;

    private bool isKnockedBack = false;

    public void GetKnockback(Transform target)
    {
        if (!isKnockedBack)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
            }
            isKnockedBack = true;
            Invoke("ResetKnockback", knockbackTime);
        }
    }

    void ResetKnockback()
    {
        isKnockedBack = false;
    }
}
