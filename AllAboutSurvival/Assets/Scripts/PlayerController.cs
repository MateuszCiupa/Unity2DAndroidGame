using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D myRB;
    private SpriteRenderer myRenderer;
    private Animator myAnimator; 
    private bool facingRight = true;
    
    [Header("Jump Settings")]
    public float jumpTime = 0.5f;
    public float jumpForce = 7f;
    public float checkRadius = 0.3f;
    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimeCounter;
    public LayerMask groundLayer;
    public Transform groundCheck;
    
    [Header("Run Settings")]
    public float maxSpeed = 8f;
    private float horizontalMove;

    private Joystick joystick;
    private Joybutton joybutton;
    private bool isPressed = false;
    private bool wasPressed = false;

    void Start() {
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
    }

    void Update() {
        horizontalMove = joystick.Horizontal;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        isPressed = joybutton.pressed;

        if(horizontalMove > 0 && !facingRight || horizontalMove < 0 && facingRight) {
            Flip();
        }

        if(Mathf.Abs(horizontalMove) <= 0.1) {
            horizontalMove = 0f;
        } 

        if(isJumping && !isPressed) {
            isJumping = false;
            wasPressed = false;
        }

        if(isJumping && jumpTimeCounter > 0) {
            jumpTimeCounter -= Time.deltaTime;
        }

        if(myAnimator != null) {
            myAnimator.SetFloat("MoveSpeed", Mathf.Abs(horizontalMove));
            myAnimator.SetBool("isGrounded", isGrounded);
        }
    }

    void FixedUpdate() { 
        if(myRB != null) {
            myRB.velocity = new Vector2(horizontalMove * maxSpeed, myRB.velocity.y);  

            if(isGrounded && isPressed && !wasPressed) {
                myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
                isJumping = true;
                jumpTimeCounter = jumpTime;
                wasPressed = true;
            }

            if(isJumping && jumpTimeCounter > 0) {
                myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
            }
        }
    }

    private void Flip() {
        facingRight = !facingRight;

        if(myRenderer != null) {
            myRenderer.flipX = !myRenderer.flipX;
        }
    }
}
