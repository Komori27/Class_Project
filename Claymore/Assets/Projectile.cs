using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifespan = 5f;
    public int damage = 5;

    private Transform target;
    private bool returning = false;
    private Vector3 initialPosition;
    private float elapsedTime = 0f;

    private void Start()
    {
        initialPosition = transform.position;
        Destroy(gameObject, lifespan);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (!returning)
        {
            // If the projectile has a target, move towards it
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            // If the projectile doesn't have a target, move in a straight line
            else
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
        elapsedTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // If the player collides with the projectile, damage the player and start the return sequence
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
