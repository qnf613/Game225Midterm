using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    [SerializeField] private float destroyPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy when it get out of bottom boundary
        if (gameObject.transform.position.y < destroyPos)
        {
            Destroy(gameObject);
        }

        if (GameObject.Find("Player") == null)
        {
            Debug.Log("GameOver!");
        }
    }
}
