using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public static int score;
    void Start()
    {
        score = 0;
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BCoin"))
        {
            score += 1;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("SCoin"))
        {
            score += 3;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("GCoin"))
        {
            score += 5;
            other.gameObject.SetActive(false);
        }

    }
}
