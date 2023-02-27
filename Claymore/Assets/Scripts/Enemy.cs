using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;

    public int maxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        
    }
    void Die() 
    {
        Debug.Log("Enemy died!");

        animator.SetBool("IsDead", true);
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
