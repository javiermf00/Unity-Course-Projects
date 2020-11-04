using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public Transform firePointLeft;
    public Transform firePointRight;
    public GameObject enemyBullet;
    public float fireRate = 1.5f;
    public float actualFireRate;

    public void Start()
    {
        actualFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (actualFireRate <= 0)
        {
            Shoot();
            actualFireRate = fireRate;

        }
        else
        {
            actualFireRate -= Time.deltaTime;
        }
    }
    void Shoot()
    {
        Instantiate(enemyBullet, firePointLeft.position, firePointLeft.rotation);
        Instantiate(enemyBullet, firePointRight.position, firePointRight.rotation);
    }
}
