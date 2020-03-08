using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;
    public int hp = 5;
    private Transform target;
    private int wayPointIdex = 0;

    void Start()
    {
        target = WayPoints.points[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= .2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wayPointIdex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wayPointIdex++;
        target = WayPoints.points[wayPointIdex];
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Bullet")
    //    {
    //        hp--;
    //        Destroy(collision.gameObject);
    //    }

    //    if (collision.tag == "Thunder")
    //    {
    //        hp--;
    //        Destroy(collision.gameObject, 0.2f);
    //    }

    //    if (hp <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
