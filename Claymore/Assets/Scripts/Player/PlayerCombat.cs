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

    private int comboCount = 0;
    private float lastAttackTime;
    private float attackTimeFrame = 1f;

    private void Start()
    {
        InvokeRepeating("ResetComboAttack", attackTimeFrame, attackTimeFrame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time - lastAttackTime > attackTimeFrame)
        {
            // play first attack animation
            animator.SetTrigger("Attack");
            comboCount = 1;
            lastAttackTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.F) && comboCount == 1 && Time.time - lastAttackTime <= attackTimeFrame)
        {
            // play second attack animation
            animator.SetTrigger("Attack2");
            comboCount = 2;
            lastAttackTime = Time.time;
        }
    }

    private void ResetComboAttack()
    {
        comboCount = 0;
        lastAttackTime = 0f;
    }


    void Attack()
    {
        animator.SetTrigger("Attack");
    }
        void AttackEnemy()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D collider in hitEnemies)
            {
                collider.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
