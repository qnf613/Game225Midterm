using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject[] coin;
    private float spawnRangeX = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCoin", 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnCoin()
    {
        int coinIndex = Random.Range(0, coin.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 5);
        Instantiate(coin[coinIndex], spawnPos, coin[coinIndex].transform.rotation);
        Invoke("SpawnCoin", Random.Range(1.0f, 2.0f));
    }
}
