using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerb : MonoBehaviour
{
   public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float slowSpeed = 2.5f;
    public float fastSpeed = 7.5f;
    private float originalSpeed;

    private Rigidbody2D rb;
    private bool isGrounded;

    public int lives = 3; 
    public Transform respawnPoint; 
    public UIManager uiManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalSpeed = moveSpeed;
        uiManager.UpdateLives(lives); 
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
        else if (collision.gameObject.CompareTag("FastPowerUp"))
        {
            moveSpeed = fastSpeed;
            Destroy(collision.gameObject);
            Invoke("ResetSpeed", 5f);
        }
        else if (collision.gameObject.CompareTag("Hazard"))
        {
            LoseLife();
        }
    }

    private void ResetSpeed()
    {
        moveSpeed = originalSpeed;
    }

    private void LoseLife()
    {
        lives--;
        uiManager.UpdateLives(lives); 

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = respawnPoint.position;
        rb.velocity = Vector2.zero; 
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOverb"); 
    }
}