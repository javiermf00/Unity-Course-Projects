using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask whatIsGround;
    public int health = 20;
    public GameObject deathEffect;

    public Transform FallCheck;

    bool isFacingRight = true;

    RaycastHit2D hit;

    public void takeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Update()
    {
        hit = Physics2D.Raycast(FallCheck.position, -transform.up, 1f, whatIsGround);
    }

    public void FixedUpdate()
    {
        if(hit.collider != false)
        {
            if (isFacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        } else
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
        }
    }
}
