using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numEnemiesToSpawn;
    public float spawnRadius;
    public Color gizmoColor;
    public Vector3 spawnPosition;
    private bool hasSpawnedEnemy = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasSpawnedEnemy && other.gameObject.CompareTag("Player"))
        {
            //Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
            Vector3 finalSpawnPosition = spawnPosition;     // + randomOffset
            Instantiate(enemyPrefab, finalSpawnPosition, Quaternion.identity);
            hasSpawnedEnemy = true;
            Debug.Log("EnemySpawned");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spawnPosition, 2f);
    }
}
