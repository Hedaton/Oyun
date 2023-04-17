using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 5f; // Karakterinizin hýzýný ayarlamak için kullanýn.
    public float jumpForce = 7f; // Karakterinizin zýplama kuvvetini ayarlamak için kullanýn.
    public float fallMultiplier = 2.5f; // Karakterinizin daha hýzlý düþmesi için kullanýn.
    public float lowJumpMultiplier = 2f; // Karakterinizin daha yavaþ düþmesi için kullanýn.
    public Transform groundCheck; // Karakterinizin yerde olup olmadýðýný kontrol etmek için kullanýn.
    public float groundCheckRadius = 0.1f; // Yer kontrolündeki yarýçapý ayarlamak için kullanýn.
    public LayerMask groundLayer; // Yer katmanýný ayarlamak için kullanýn.

    private Rigidbody2D rb;
    private bool isGrounded; // Karakterinizin yerde olup olmadýðýný tutmak için kullanýn.

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileþenini alýn.
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal"); // W, A, S ve D tuþlarýndan gelen yatay hareket deðerini alýn.

        Vector2 movement = new Vector2(horizontalMovement, 0f); // Sadece yatay hareketi kullanýn.

        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y); // Rigidbody'nin hýzýný, yatay hareket deðeriyle ve mevcut y dikey hýzýyla birlikte ayarlayýn.

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Karakterinizin yerde olup olmadýðýný kontrol edin.

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) // Karakteriniz yerde ve Space tuþuna basýldýysa zýplayýn.
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Rigidbody'nin yukarý doðru hýzýný ayarlayýn.
        }

        // Karakteriniz havadayken daha hýzlý düþmesi veya yavaþlamasý için kodu aþaðýdaki gibi deðiþtirin.
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
