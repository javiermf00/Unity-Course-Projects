using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed = 5f;
    Vector2 movement;
    public bool hasKey;

    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            hasKey = true;
        }

        if (collision.gameObject.CompareTag("Chest") && hasKey)
        {
            Chest.OpenChest();
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            ReturnToSpawn();
        }
    }

    void ReturnToSpawn()
    {
        rb.position = SpawnPoint.position;
    }

}
