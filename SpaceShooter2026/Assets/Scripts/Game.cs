using UnityEngine;

public class Game : MonoBehaviour
{
    // set in inspector
    public float enemySpawnDelay;
    public GameObject enemyPrefab;
    public BoxCollider2D enemySpawnRange;

    // private fields
    private float enemySpawnTimer;

    private void SpawnEnemy() {
        Vector3 enemySpawnPt = new Vector3(
            Random.Range(enemySpawnRange.bounds.min.x, enemySpawnRange.bounds.max.x),
            Random.Range(enemySpawnRange.bounds.min.y, enemySpawnRange.bounds.max.y),
            0);
        Instantiate(enemyPrefab, enemySpawnPt, Quaternion.identity);
    }

    void Update()
    {
        enemySpawnTimer += Time.deltaTime;
        if (enemySpawnTimer >= enemySpawnDelay) {
            SpawnEnemy();
            enemySpawnTimer = 0.0f;
        }
    }
}
