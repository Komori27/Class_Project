using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Update()
    {
        if(Time.time >= nextAttackTime) 
        {
            if(Input.GetKeyDown(KeyCode.F)) 
             {
                Attack();
                nextAttackTime= Time.time + 1f / attackRate;
             }
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
    }
        void AttackEnemy()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}