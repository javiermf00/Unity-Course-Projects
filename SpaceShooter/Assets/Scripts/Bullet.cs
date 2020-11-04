using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public int damage = 10;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        Asteroide asteroid = collision.GetComponent<Asteroide>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
        }else if (collision.gameObject.CompareTag("Asteroid"))
        {
            asteroid.TakeDamage(damage);
        }
        /*Enemy enemy = collision.GetComponent <Enemy>();
        

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }*/
        Destroy(gameObject);
    }

}
