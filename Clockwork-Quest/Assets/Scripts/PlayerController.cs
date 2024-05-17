using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float slowSpeed = 2.5f;
    public float fastSpeed = 7.5f;
    private float originalSpeed;
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalSpeed = moveSpeed;
    }
    
    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SlowPowerUp"))
        {
            moveSpeed = slowSpeed;
            Destroy(collision.gameObject);
            Invoke("ResetSpeed", 5f);
        }

        if (collision.gameObject.CompareTag("FastPowerUp"))
        {
            moveSpeed = fastSpeed;
            Destroy(collision.gameObject);
            Invoke("ResetSpeed", 5f);
        }
    }

    private void ResetSpeed()
    {
        moveSpeed = originalSpeed;
    }
}