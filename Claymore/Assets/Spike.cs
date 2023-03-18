using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    public int attackDamage = 0;
    public float attackCooldown = 2f;
    private GameObject player;
    //private PlayerHealth playerHealth;
    private bool canAttack = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();
    }
/*
    private void Update()
    {
        void Attack()
        {
            if (canAttack && Vector3.Distance(transform.position, player.transform.position) <= attackRange)
            {
                canAttack = false;
                playerHealth.TakeDamage(attackDamage);
                Invoke("ResetAttack", attackCooldown);
            }
        }
    }
*/
/*
    public void Attack()
    {
        // Deal damage to the player
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }
*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canAttack = false;
            other.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            Invoke("ResetAttack", attackCooldown);
        }
    }

    private void ResetAttack()
    {
        canAttack = true;
    }


}
