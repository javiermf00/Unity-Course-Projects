using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask layerMask;
    public Vector3 startPosition;

    void Start()
    {
        startPosition = gameObject.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && canMove(new Vector2(0, 1)))
        {
            gameObject.transform.Translate(new Vector2(0, -1));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && canMove(new Vector2(0, -1)))
        {
            gameObject.transform.Translate(new Vector2(0, 1));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && canMove(new Vector2(1, 0)))
        {
            gameObject.transform.Translate(new Vector2(-1, 0));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove(new Vector2(-1, 0)))
        {
            gameObject.transform.Translate(new Vector2(1, 0));
        }

        
    }
    private bool canMove(Vector2 direction)
    {
      
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, direction, 1, layerMask);
        if (hit.collider != null)
        {
            return false;
        }
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        gameObject.transform.position = startPosition;
    }
}
