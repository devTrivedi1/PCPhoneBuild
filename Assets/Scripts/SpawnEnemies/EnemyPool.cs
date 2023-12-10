using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool instance;
    [SerializeField] List<GameObject> enemyPool = new List<GameObject>();
    [SerializeField] int maxEnemiesInPool = 20;
    [SerializeField] GameObject enemy;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < maxEnemiesInPool; i++)
        {
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            enemyPool.Add(newEnemy);
            newEnemy.SetActive(false);
        }
    }

    public GameObject GetEnemy()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
            {
                return enemyPool[i];
            }
        }
        return null;
    }

}
