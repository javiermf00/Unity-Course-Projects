using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSpawner : MonoBehaviour
{
 
    public GameObject Tank;
    public float spawnRate;
    public float nextSpawn;

    void Start()
    {
        spawnRate = 2.5f;
        nextSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            Spawn();
            nextSpawn = Time.time + spawnRate;
        }
    }

    void Spawn()
    {
        Instantiate(Tank, transform.position, Quaternion.Euler(0, 0, 90));
    }

}
