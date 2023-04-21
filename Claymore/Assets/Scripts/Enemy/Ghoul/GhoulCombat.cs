using UnityEngine;

public class GhoulCombat : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackCooldown = 2f;
    public float attackRange = 2f;

    private bool canAttack = true;
    private Animator animator;
    private GameObject player;
    private PlayerHealth playerHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {

            if (canAttack && Vector3.Distance(transform.position, player.transform.position) <= attackRange)
            {
                canAttack = false;
                Attack();
                animator.SetTrigger("Attack");
                playerHealth.TakeDamage(attackDamage);
                Invoke("ResetAttack", attackCooldown);
            }
        

    }
    public void Attack()
    {
        // Deal damage to the player
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }

    private void ResetAttack()
    {
        canAttack = true;
    }
}
