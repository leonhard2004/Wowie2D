using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
	public float speed;
	
    public float maxSpeed;
    public float fHorizontalDamping;
    public float jumpForce;
    public float fcutJumpHeight;
    public float fcutJumpDamping;


    private float moveInput;
    float jumpInput;


    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool canJump;
    private bool isGrounded;
    public Transform groundCheckPoint;
    public Transform groundCheckPoint2;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private float fJumpPressedRemember;
    public float fJumpPressedRememberTime;
    private float fGroundedRemember;
    public float fGroundedRememberTime;


    public Animator anim;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        fJumpPressedRemember -= Time.deltaTime;
        fGroundedRemember -= Time.deltaTime;
        if (jumpInput > 0)
        {
            fJumpPressedRemember = fJumpPressedRememberTime;
        }
        if(isGrounded == true)
        {
            fGroundedRemember = fGroundedRememberTime;
            canJump = true;
        }
        else if(isGrounded == false)
        {
            canJump = false;
        }

        if(moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else if (moveInput != 0)
        {
            anim.SetBool("isRunning", true);
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround) || Physics2D.OverlapCircle(groundCheckPoint2.position, groundCheckRadius, whatIsGround);

        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if((fJumpPressedRemember > 0) && canJump == true && (fGroundedRemember > 0))
        {
            anim.SetTrigger("Takeoff");
            fJumpPressedRemember = 0;
            fGroundedRemember = 0;
            rb.velocity = Vector2.up * jumpForce;
        }
        if(jumpInput == 0 )
        {
            if (rb.velocity.y > 0)
            {
                //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * fcutJumpHeight);
                float fVerticalVelocity = rb.velocity.y * fcutJumpHeight;
                //fVerticalVelocity *= fcutJumpHeight;
                //fVerticalVelocity *= Mathf.Pow(1f - fcutJumpDamping, Time.deltaTime * 10f);
                rb.velocity = new Vector2(rb.velocity.x, fVerticalVelocity);
            }
        }
        if(rb.velocity.y != 0)
        {
            Debug.Log("isJumping");
            anim.SetBool("isJumping", true);
        }
        if (rb.velocity.y == 0)
        {
            Debug.Log("isJumping false");
            anim.SetBool("isJumping", false);
        }

        float fHorizontalVelocity = rb.velocity.x;
        fHorizontalVelocity += moveInput * speed;
        fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDamping, Time.deltaTime * 10f);
        rb.velocity = new Vector2(fHorizontalVelocity, rb.velocity.y);
        if (rb.velocity.x > maxSpeed) 
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnMovement(InputValue value)
    {
        moveInput = value.Get<float>();
        
    }

    void OnJump(InputValue value)
    {
        jumpInput = value.Get<float>();
    }
}