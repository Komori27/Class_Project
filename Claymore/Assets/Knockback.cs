using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public Vector2 forceDirection = Vector2.left;
    public float forceMagnitude = 100f;
    public void MyMethodHandler()
    {
        Debug.Log("Knockback");
        Vector2 forceDirection = -transform.right; forceDirection.y = 0;
        forceDirection.Normalize();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector2 force = forceDirection.normalized * forceMagnitude;
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
