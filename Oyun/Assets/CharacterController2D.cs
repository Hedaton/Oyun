using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 5f; // Karakterinizin h�z�n� ayarlamak i�in kullan�n.
    public float jumpForce = 7f; // Karakterinizin z�plama kuvvetini ayarlamak i�in kullan�n.
    public float fallMultiplier = 2.5f; // Karakterinizin daha h�zl� d��mesi i�in kullan�n.
    public float lowJumpMultiplier = 2f; // Karakterinizin daha yava� d��mesi i�in kullan�n.
    public Transform groundCheck; // Karakterinizin yerde olup olmad���n� kontrol etmek i�in kullan�n.
    public float groundCheckRadius = 0.1f; // Yer kontrol�ndeki yar��ap� ayarlamak i�in kullan�n.
    public LayerMask groundLayer; // Yer katman�n� ayarlamak i�in kullan�n.

    private Rigidbody2D rb;
    private bool isGrounded; // Karakterinizin yerde olup olmad���n� tutmak i�in kullan�n.

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bile�enini al�n.
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal"); // W, A, S ve D tu�lar�ndan gelen yatay hareket de�erini al�n.

        Vector2 movement = new Vector2(horizontalMovement, 0f); // Sadece yatay hareketi kullan�n.

        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y); // Rigidbody'nin h�z�n�, yatay hareket de�eriyle ve mevcut y dikey h�z�yla birlikte ayarlay�n.

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Karakterinizin yerde olup olmad���n� kontrol edin.

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) // Karakteriniz yerde ve Space tu�una bas�ld�ysa z�play�n.
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Rigidbody'nin yukar� do�ru h�z�n� ayarlay�n.
        }

        // Karakteriniz havadayken daha h�zl� d��mesi veya yava�lamas� i�in kodu a�a��daki gibi de�i�tirin.
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
