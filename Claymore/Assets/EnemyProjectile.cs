using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float projectileInterval = 2;
    public int damage = 10;
    public float projectileLifespan = 5f;
    public Enemy enemy;
    Collider2D collider;
    private Transform playerTransform;
    public bool canShoot = true;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("ShootProjectile", 0f, projectileInterval); // Shoot a projectile at set intervals
    }

    private void Update()
    {
        if (enemy.currentHealth <= 0)
        {
            canShoot = false;
            this.enabled = false;
            collider.enabled = false;
        }
    }

    private void ShootProjectile()
    {
        if (canShoot)
        {
            // Create a new projectile and set its target to the player's position
            GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile projectile = newProjectile.GetComponent<Projectile>();
            projectile.SetTarget(playerTransform);

            // Set the projectile's speed and lifespan
            projectile.speed = projectileSpeed;
            projectile.lifespan = projectileLifespan;

            // Ignore collision between the projectile and the enemy
            Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            canShoot = false;
            Invoke("ResetShoot", projectileInterval); // Wait for the projectile interval before allowing the enemy to shoot again
        }
    }

    private void ResetShoot()
    {
        if (enemy.currentHealth >= 0)
        {
            canShoot = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // If the player collides with the enemy, damage the player
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

}
