using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator myAnim;
    float speed = 5f;

    float jumpSpeed = 14f;
    bool isGrounded;
    public Transform feetPos;
    [SerializeField]
    float checkRadius = 0.3f;
    public LayerMask whatIsGround;

    public bool IsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        myAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if(rb.velocity.x != 0)
        {
            myAnim.SetBool("IsRunning", true);
        }
        else if(rb.velocity.x == 0){
            myAnim.SetBool("IsRunning", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Death();
            FindObjectOfType<ScoreManager>().GameEnded();
        }
    }

    void Death()
    {
        Destroy(gameObject);
        IsAlive = false;
    }
}
