using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float DistanceSpawnPointAndPlayer;

    public int numberOfEnemies = 5; // Yaratılacak düşman sayısı
    public float spawnInterval = 10f; // Yaratma aralığı (saniye)
    private float timer = 0f;

    private void Update()
    {
        if (Vector3.Distance(PlayerC.Instance.transform.position, transform.position) < DistanceSpawnPointAndPlayer)
        {
            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                for (int i = 0; i < numberOfEnemies; i++)
                {
                    SpawnEnemy();
                }

                timer = 0f;
            }
        }
    }

    void SpawnEnemy()
    {
        // Belirtilen düşman prefab'ını rastgele bir konumda yarat
        Instantiate(enemyPrefab, new Vector3(Random.Range(transform.position.x-10f, transform.position.x + 10f), 1f, Random.Range(transform.position.z - 10f, transform.position.x  + 10f)), Quaternion.identity);
    }

}
