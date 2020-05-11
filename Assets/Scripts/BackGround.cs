using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject[] cloud;
    private float spawnRangeX = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCloud", 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnCloud()
    {
        int cloudIndex = Random.Range(0, cloud.Length);
        Vector2 spawnPos = new Vector2((Random.Range(-spawnRangeX, spawnRangeX)), 6);
        Instantiate(cloud[cloudIndex], spawnPos, cloud[cloudIndex].transform.rotation);
        Invoke("SpawnCloud", Random.Range(3.0f, 4.0f));
    }
}
