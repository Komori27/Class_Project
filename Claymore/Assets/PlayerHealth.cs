using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public float maxHealth = 100f;     // The player's maximum health
    public float currentHealth;        // The player's current health (initially set to maxHealth)

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Subtract the damage from the player's current health
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        // If the player's health drops below 0, they die
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
    }
}
