using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy; 
    public int numberOfEnemies = 1; // number of enemies you want to spawn.
    public float plateSize = 10f; // The size of the plates.

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Random position on the plate.
            Vector3 spawnPosition = new Vector3(
                Random.Range(-plateSize / 2, plateSize / 2),
                6.7f,
                Random.Range(-plateSize / 2, plateSize / 2)
            ) + transform.position; // Make sure it's relative to the platform's position.

            // Instantiate the enemy at the random position.
            GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);

            // Correct the Y position based on the enemy's collider height to ensure it spawns on top of the platform.
            Collider enemyCollider = spawnedEnemy.GetComponent<Collider>();
            if (enemyCollider != null)
            {
                float enemyHeight = enemyCollider.bounds.extents.y; // Use extents.y which is half the height of the collider.
                // This positions the enemy so that its base is on the platform, not its center.
                spawnedEnemy.transform.position = new Vector3(spawnedEnemy.transform.position.x, enemyHeight, spawnedEnemy.transform.position.z);
            }

            // If the platform's scale is affecting the enemy, reset the enemy's scale after instantiation
            spawnedEnemy.transform.localScale = new Vector3(1, 1, 1); 
        }
    }
}


