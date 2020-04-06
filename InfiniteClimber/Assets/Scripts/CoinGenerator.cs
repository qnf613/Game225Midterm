using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject[] coin;
    private float spawnRangeX = 3.5f;
    private float timer;
    private float start, end;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCoin", 3);
        timer = 0.0f;
        start = 0.8f;
        end = 1.9f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer != 0.0f && (timer % 20.0) == 0.0)
        {
            start += 0.1f;
            end += 0.2f;
        }
    }

    void SpawnCoin()
    {
        int coinIndex = Random.Range(0, coin.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 6);
        Instantiate(coin[coinIndex], spawnPos, coin[coinIndex].transform.rotation);
        Invoke("SpawnCoin", Random.Range(start, end));
    }
}
