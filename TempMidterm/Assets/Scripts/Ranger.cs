using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : MonoBehaviour
{
    private Transform target;


    public float range = 15f;
    public float fireRate = 1f;
    private float fireCount = 0f;

    public Transform thing2Rotate;

    public GameObject projectile;
    public Transform firePoint; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Targeting", 0f, 0.5f);
    }

    void Targeting()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shortestEnemy = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject Enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, Enemy.transform.position);
            if (distanceToEnemy < shortestEnemy)
            {
                shortestEnemy = distanceToEnemy;
                nearestEnemy = Enemy;
            }
        }
        if (nearestEnemy != null && shortestEnemy <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        
        Vector3 direction = target.position - transform.position;
        Quaternion lookRoration = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRoration.eulerAngles;
        thing2Rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if (fireCount <=0f)
        {
            Shoot();
            fireCount = 1f / fireRate;
        }
        fireCount -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Shooting bullet = bulletGO.GetComponent<Shooting>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
