using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public int maxHealth = 5;
    public int currentHealth;
    public Rigidbody2D rb;
    public HealthBar healthBar;
    Vector2 movement;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        
        GetComponent<SpriteRenderer>().color = Color.red;

        Invoke("RestoreColor", 1);
        

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

    void RestoreColor()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
