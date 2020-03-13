using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    private float spawnRangeX = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnPlatform", 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPlatform()
    {
        Vector2 spawnPos = new Vector2((Random.Range(-spawnRangeX, spawnRangeX)), 6);
        Instantiate(enemy, spawnPos, enemy.transform.rotation);
        Invoke("SpawnPlatform", Random.Range(3.0f, 4.5f));
    }


}
