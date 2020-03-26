using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject Panel;
    public bool isOver = false;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") == null)
        {
            Debug.Log("GameOver!");
            isOver = true;
        }
        if (isOver == true)
        {
            Panel.SetActive(true);
        }

    }
}
