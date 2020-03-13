using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platform;
    private float spawnRangeX = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnPlatform", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlatform()
    {
        int platformIndex = Random.Range(0, platform.Length);
        Vector2 spawnPos = new Vector2((Random.Range(-spawnRangeX, spawnRangeX)-7.0f), 4);
        Instantiate(platform[platformIndex], spawnPos, platform[platformIndex].transform.rotation);
        Invoke("SpawnPlatform", Random.Range(1.7f, 2.2f));
    }
}
