using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platform;
    private float spawnRangeX = 3.5f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnPlatform", 1);
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    void SpawnPlatform()
    {
        if (timer <= 30.0f)
        {
            int platformIndex = Random.Range(0, 3);
            Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 5);
            Instantiate(platform[platformIndex], spawnPos, platform[platformIndex].transform.rotation);
            Invoke("SpawnPlatform", Random.Range(1.5f, 2.0f));
        }

        else if (timer >= 31.0f && timer <= 60.0f)
        {
            int platformIndex = Random.Range(1, 4);
            Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 5);
            Instantiate(platform[platformIndex], spawnPos, platform[platformIndex].transform.rotation);
            Invoke("SpawnPlatform", Random.Range(1.7f, 2.2f));
        }

        else if (timer > 60.0f)
        {
            int platformIndex = Random.Range(2, 5);
            Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 5);
            Instantiate(platform[platformIndex], spawnPos, platform[platformIndex].transform.rotation);
            Invoke("SpawnPlatform", Random.Range(2.0f, 2.5f));
        }
        
    }
}
