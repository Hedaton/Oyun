using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    const float groundCheckRadius = 0.6f;
    public float movementSpeed;
    public float initialMovementSpeed = 200f;
    public float jumpForce = 45f;

    float xInput;
    public float runningSpeed = 1.3f;

    public bool isGrounded;
    bool facingRight = true;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        movementSpeed = initialMovementSpeed;
    }


    void Update()
    {
        KiCharge();
        Running();
        Jump();
        Attack();

        // Hareket ettirme
        xInput = Input.GetAxisRaw("Horizontal");

    }

    private void FixedUpdate()
    {
        Move(xInput);
        PlayerFacing();
        GroundCheck();

     
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));



    }

    void KiCharge()
    {
        if(Input.GetKey(KeyCode.S))
        {
            animator.SetBool("KiCharge", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("KiCharge", false);
        }
    }

    void Running()
    {
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                movementSpeed *= runningSpeed;
                animator.speed = 2f;

            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                movementSpeed = initialMovementSpeed;
                animator.speed = 1f;

            }
    }

   

    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            animator.SetBool("Jump", true);
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    // Karakter yere temas ediyormu isGrounded
    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }

        animator.SetBool("Jump", !isGrounded);

    }

    void Move(float dir)
    {
        rb.velocity = new Vector2(movementSpeed * dir * Time.deltaTime, rb.velocity.y);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }
    }

    // Karakteri döndürme
    void PlayerFacing()
    {
        if (xInput != 0)
        {
            rb.AddForce(new Vector2(xInput * movementSpeed, 0f));
        }

        if (xInput > 0 && !facingRight)
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;

            facingRight = !facingRight;
        }

        if (xInput < 0 && facingRight)
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;

            facingRight = !facingRight;
        }
    }

}
