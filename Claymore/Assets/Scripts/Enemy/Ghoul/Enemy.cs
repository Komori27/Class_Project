using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;


    [SerializeField] bool destroyObject = false;
    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead = false;
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

    void Die() 
    {
        Debug.Log("Enemy died!");
        isDead = true;
        animator.SetBool("IsDead", true);
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
        Collider2D[] colliders = GetComponents<Collider2D>(); // Get all colliders attached to the object
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false; // Disable each collider
        }
        if (destroyObject)
        {
            Destroy(gameObject);
        }
        else             //---------------------------------
        {
            Destroy(gameObject, 10);
        }               //---------------------------------
        this.enabled = false;
    }
}
