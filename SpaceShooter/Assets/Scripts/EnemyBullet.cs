using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public int damage = 1;
    public Rigidbody2D rb;
    public float speed = 10f;
    
    void Start()
    {
        rb.velocity = -transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
