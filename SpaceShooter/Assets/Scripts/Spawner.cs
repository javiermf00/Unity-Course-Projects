using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Asteroid;
    public float enemyEverySeconds = 4f;
    public float random;
    public float asteroidEverySeconds = 1f;

    private Vector2 Boundary;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, enemyEverySeconds);
        InvokeRepeating("SpawnAsteroid", 2, asteroidEverySeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
        random = Random.Range(-10.7f, 10.7f);
        Boundary = new Vector2(random, transform.position.y);
    }
    void SpawnEnemy()
    {
        Instantiate(Enemy, Boundary, Quaternion.identity);
    }
    void SpawnAsteroid()
    {
        Instantiate(Asteroid, Boundary, Quaternion.identity);
    }
}
