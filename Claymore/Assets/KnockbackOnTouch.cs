using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackOnTouch : MonoBehaviour
{
    public Knockback knockbackScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            knockbackScript.TakeKnockback(knockbackDirection);
        }
    }
}
