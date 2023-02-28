using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator animator;
    public float maxHealth = 100f;     // The player's maximum health
    public float currentHealth;        // The player's current health (initially set to maxHealth)

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("Hurt");
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
    }
}
