using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    public int attackDamage = 0;
    public float attackCooldown = 2f;
    private GameObject player;
    private bool canAttack = true;
    public float knockbackForce = 10f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canAttack && other.CompareTag("Player"))
        {
            //Transform playerTransform = other.transform;
            canAttack = false;
            other.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            //Debug.Log(attackDamage);
            GetComponent<Knockback>().GetKnockback(other.transform);
            Invoke(nameof(ResetAttack), attackCooldown);
        }
    }

    private void ResetAttack()
    {
        canAttack = true;
    }


}
