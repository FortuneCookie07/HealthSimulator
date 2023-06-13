using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;

    public float speed = 8f;
    public float jumpingPower = 16f;
    
    private bool isFacingRight = true;

    public float maxBMI = 40;
    public float currentBMI;

    public BMIbar BMIbar;

    [SerializeField] private Rigidbody2D rb; //visible in component view
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool isInvincible = false; // To avoid taking damage continuously

    void Start()
    {
        currentBMI = maxBMI;
        BMIbar.SetMaxBMI(maxBMI);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); 

        if (Input.GetButtonDown("Jump") && IsGrounded())
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            LoseBMI(5);
        }

        Flip();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void LoseBMI(float loss)
    {
        currentBMI -= loss;
        BMIbar.SetBMI(currentBMI);
    }

    // Called when the player collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isInvincible)
            return;

        // Check if the collision object has a Rigidbody and a CapsuleCollider
        Rigidbody2D otherRigidbody = collision.collider.GetComponent<Rigidbody2D>();
        CapsuleCollider2D otherCapsuleCollider = collision.collider.GetComponent<CapsuleCollider2D>();

        if (otherRigidbody != null && otherCapsuleCollider != null)
        {
            // Apply damage to the player
            LoseBMI(10);

            // Make the player invincible for a short period to avoid continuous damage
            StartCoroutine(MakeInvincible());
        }
    }

    IEnumerator MakeInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(1f); // Invincibility duration
        isInvincible = false;
    }
}
