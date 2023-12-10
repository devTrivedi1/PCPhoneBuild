using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
public class InstantiateEnemy : MonoBehaviour
{

    [SerializeField] MinMaxCurve randomValue;

    [SerializeField] int spawnBatchPerSpawn;
    [SerializeField] float spawnRate;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemiesInBatches), spawnRate, spawnRate);
    }
    void SpawnEnemiesInBatches()
    {
        for (int i = 0; i < spawnBatchPerSpawn; i++)
        {
            float randomNumber = Random.Range(randomValue.constantMin, randomValue.constantMax);
            Vector3 randomPosition = new Vector3(randomNumber, 0, randomNumber);
            GameObject enemy = EnemyPool.instance.GetEnemy();
            if (enemy == null) return;
            enemy.SetActive(true);
            enemy.transform.position = randomPosition;
        }

    }

}
