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

    void Start() {
        currentBMI = maxBMI;
        BMIbar.SetMaxBMI(maxBMI);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); 

        if (Input.GetButtonDown("Jump") && IsGrounded())
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            loseBMI(5);
        }

        Flip();
    }

    void loseBMI(float loss) {
        currentBMI -= loss;

        BMIbar.SetBMI(currentBMI);
    } 

    private void FixedUpdate()
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
}
