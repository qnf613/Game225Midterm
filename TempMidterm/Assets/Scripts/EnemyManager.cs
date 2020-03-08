using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBtwEnemy = 1f;
    private float countdown = 5f;
    private int enemyNum = 0;
    
    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnEnemy();
            countdown = timeBtwEnemy;
        }

        countdown -= Time.deltaTime;
    }

    void SpawnEnemy()
    {
        if (enemyNum < 10)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            enemyNum++;
        }
        

    }
}
