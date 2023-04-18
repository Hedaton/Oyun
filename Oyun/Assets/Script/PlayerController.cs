using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontal;
    public bool isGrounded;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true; //saða bakýyor
    private bool isWalking = false;
    const float groundCheckRadius = 0.2f;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheckCollider;
    [SerializeField] private LayerMask groundLayer;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("Jump", true);
        }



        flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        GroundCheck();
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    }
    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if(colliders.Length>0)
            isGrounded = true;
        animator.SetBool("Jump", !isGrounded);

    }

    private void flip()
    {
        if (isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

}