using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform target;
    public float speed = 70f;

    public void Seek (Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceFrame, Space.World);
    }

    void HitTarget()
    {
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
