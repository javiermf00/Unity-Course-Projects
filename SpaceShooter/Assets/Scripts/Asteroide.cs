using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 5f;
    public float rotationz = 0.5f;
    public int health = 20;
    

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.up * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationz);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (collision.gameObject.tag.Equals("Player"))
        {
            player.TakeDamage(1);
            Destroy(gameObject);
        }
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
