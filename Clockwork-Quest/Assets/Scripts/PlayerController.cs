using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float slowSpeed = 2.5f;
    public float fastSpeed = 7.5f;

    public Transform respawnPoint;

    private float originalSpeed;
    private bool isGrounded;

    private UIManager um;
    private GameManager gm;
    private Transform playerTransfrom;
    private Rigidbody2D rigidb;
    private SpriteRenderer sprite;
    private Animator animator;

    private void Awake()
    {
        originalSpeed = moveSpeed;
    }

    private void Start()
    {
        playerTransfrom = GetComponent<Transform>();
        rigidb = GetComponent<Rigidbody2D>();
        sprite = rigidb.GetComponent<SpriteRenderer>();
        animator = rigidb.GetComponent<Animator>();
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
        rigidb.velocity = new Vector2(moveInput * moveSpeed, rigidb.velocity.y);
        if (moveInput < 0)
        {
            sprite.flipX = false;
        }
        else if (moveInput > 0)
        {
            sprite.flipX = true;
        }
    }

    private void Jump()
    {
        if ((Input.GetButtonDown("Vertical") || Input.GetButtonDown("Jump")) && isGrounded) //W tuşu yada Space bar
        {
            rigidb.velocity = new Vector2(rigidb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    public void ResetSpeed()
    {
        moveSpeed = originalSpeed;
    }

    public void Respawn()
    {
        transform.position = respawnPoint.position;
        rigidb.velocity = Vector2.zero;
    }

    private void UpdateAnimator()
    {
        float speed = Mathf.Abs(rigidb.velocity.x); // Mutlak değerini alarak hızı pozitif yapar
        animator.SetFloat("Speed", speed);
        animator.SetBool("IsGrounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Hazard"))
        {
            GameManager.instance.Damage(10);
            GameManager.instance.LoseLife();
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
            GameManager.instance.AddPowerUp();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ItemPlus"))
        {
            GameManager.instance.ItemCollected();
            Destroy(collision.gameObject);
        }
    }
}