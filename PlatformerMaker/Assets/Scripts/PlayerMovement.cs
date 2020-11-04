using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator myAnimator;
    float moveImput;
    float runSpeed = 5f;
    float jumpSpeed = 5f;
    bool facingRight = true;
    float jumpTimeCounter;
    float jumpTime = 0.30f;
    bool isJumping;

    bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameMaker.playing)
        {
            return;
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpSpeed;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpSpeed;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    private void FixedUpdate()
    {
        if (!GameMaker.playing)
        {
            return;
        }

        moveImput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveImput * runSpeed, rb.velocity.y);

        //Knowing when Player is moving so animator´s bool "Running" can be set to true or false
        if (moveImput != 0)
        {
            myAnimator.SetBool("Running", true);
        }
        else if (moveImput == 0)
        {
            myAnimator.SetBool("Running", false);
        }

        //If´s for knowing when he is going left or going right
        if (facingRight == false && moveImput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveImput < 0)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0);
    }
}
