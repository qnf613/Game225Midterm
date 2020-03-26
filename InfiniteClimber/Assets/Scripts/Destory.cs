using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    [SerializeField] private float destroyPosX;
    [SerializeField] private float destroyPosY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy when it get out of bottom boundary
        if (gameObject.transform.position.y < destroyPosY)
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.x > destroyPosX || gameObject.transform.position.x < -destroyPosX)
        {
            Destroy(gameObject);
        }
    }
}
