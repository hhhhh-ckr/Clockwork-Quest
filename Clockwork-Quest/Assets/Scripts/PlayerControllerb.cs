using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerb : MonoBehaviour
{
    public static PlayerControllerb instance;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float slowSpeed = 2.5f;
    public float fastSpeed = 7.5f;
    public int lives = 3;

    
    public Transform respawnPoint;
    public UIManager uiManager;
    public PerformanceEvaluatorb performanceEvaluator; // Performans değerlendirici

    private float originalSpeed;
    private bool isGrounded;

    private Rigidbody2D rb;
    private SpriteRenderer Sprite;
    private Animator animator;

    private void Awake()
    {
        originalSpeed = moveSpeed;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sprite = rb.GetComponent<SpriteRenderer>();
        animator = rb.GetComponent<Animator>();
        uiManager.UpdateLives(lives); 
    }

    private void Update()
    {
        Move();
        Jump();
        UpdateAnimator();
        LeftMouseClick();
    }
    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (moveInput < 0)
        {
            Sprite.flipX = false;
        }
        else if (moveInput > 0)
        {
            Sprite.flipX = true;
        }
    }

    private void Jump()
    {
        if ((Input.GetButtonDown("Vertical") || Input.GetButtonDown("Jump")) && isGrounded) //W tuşu yada Space bar
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }
    
    private void LeftMouseClick()
    {
        if (Input.GetMouseButton(0)) //Mouse sol tuşu basılı tutma
        {
            GameManagerb.instance.UsePowerUp();
        }
        else if (moveSpeed != originalSpeed)
        {
            ResetSpeed();
        }
    }

    private void UpdateAnimator()
    {
        float speed = Mathf.Abs(rb.velocity.x); // Mutlak değerini alarak hızı pozitif yapar
        animator.SetFloat("Speed", speed);
        
        animator.SetBool("IsGrounded", isGrounded);
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
            GameManagerb.instance.AddPowerUp();
            Destroy(collision.gameObject);
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