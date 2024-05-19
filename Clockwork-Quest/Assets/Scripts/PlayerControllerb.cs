using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerb : MonoBehaviour
{
    public Animator animator;
    
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
    public PerformanceEvaluatorb performanceEvaluator; // Performans değerlendirici

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
        UpdateAnimator();
    }
    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if ((Input.GetButtonDown("Vertical") || Input.GetButtonDown("Jump")) && isGrounded) //W tuşu yada Space bar
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
            isGrounded = false;
        }
    }
    
    private void UpdateAnimator()
    {
        float speed = Mathf.Abs(rb.velocity.x); // Mutlak değerini alarak hızı pozitif yapar
        animator.SetFloat("Speed", moveSpeed);
        
        animator.SetBool("IsGrounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
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
            performanceEvaluator.RecordDamage(10); // Örnek hasar miktarı
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
        int performanceScore = performanceEvaluator.CalculatePerformanceScore();
        string performanceComment = performanceEvaluator.GetPerformanceComment(performanceScore);
        GameManagerb.instance.performanceMessage = performanceComment; // Mesajı GameManager'da sakla
        SceneManager.LoadScene("GameOverb"); 
    }
}