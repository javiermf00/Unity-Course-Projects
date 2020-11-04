using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowSpawner : MonoBehaviour
{
    public GameObject Tank;
    public float spawnRate;
    public float nextSpawn;

    void Start()
    {
        spawnRate = 3f;
        nextSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            Spawn();
            nextSpawn = Time.time + spawnRate;
        }
    }

    void Spawn()
    {
        Instantiate(Tank, transform.position, Quaternion.Euler(0, 0, -90));
    }
}
