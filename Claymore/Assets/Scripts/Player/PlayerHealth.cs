using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Animator animator;
    public float maxHealth = 100f;     // The player's maximum health
    public float currentHealth;        // The player's current health (initially set to maxHealth)
    public Image hudImage;
    public float minSize = 50f;
    public float maxSize = 200f;

    public bool isDead = false;

    [SerializeField] GameManager gameManager;

    [SerializeField] Behaviour objectTurnOffOnDeath;
    [SerializeField] Behaviour objectTurnOffOnDeath2;
    [SerializeField] Behaviour objectTurnOffOnDeath3;

    public Rigidbody2D rb;

    public PlayerHealthHUD healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnValidate()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();

            if (objectTurnOffOnDeath != null)
            {
                objectTurnOffOnDeath.enabled = false;
                objectTurnOffOnDeath2.enabled = false;
                objectTurnOffOnDeath3.enabled = false;
            }

            rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
            Collider2D[] colliders = GetComponents<Collider2D>(); // Get all colliders attached to the object
           
            foreach (Collider2D collider in colliders)
            {
                collider.enabled = false; // Disable each collider
            }
        }
        else
        {
            animator.SetTrigger("Hurt");
        }
        healthBar.SetHealth(currentHealth);
    }
    /*
    void Update()
    {
        float size = Mathf.Lerp(minSize, maxSize, (float)currentHealth / 100f);
        hudImage.rectTransform.sizeDelta = new Vector2(size, size);
    }
    */
    public void Die()
    {
        Debug.Log("Player died!");
        gameManager.GameOver();
    }
}
