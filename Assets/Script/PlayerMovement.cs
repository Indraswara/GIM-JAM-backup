using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput; 
    Vector2 jumpInput;
    float fireInput;
    Rigidbody2D myRigidbody;
    BoxCollider2D boxCollider;
    Animator anim;

    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpPower = 15f;
    [SerializeField] private LayerMask platformLayer;
    
    [SerializeField] GameObject arrow; 
    [SerializeField] Transform bow; 
    public float attackCooldown = 2f;
    private float attackTimer;
  
    public float knockbackVelocity = 5f;
    public float knockbackTimer;
    public float knocbackDuration = .2f;
    public bool knockedFromRight;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        anim.SetBool("isRunning", moveInput.x != 0);

        if(attackTimer > 0)
            attackTimer -= Time.deltaTime;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if(isGrounded())
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpPower);
            }
    }

    void OnFire()
    {
        if(attackTimer <= 0)
        {
            Instantiate(arrow, bow.position, transform.rotation);
            anim.SetTrigger("isShooting");

            attackTimer = attackCooldown;
        }
    }

    void Run()
    {
        if(knockbackTimer <= 0)
        {
            Vector2 playerVelocity = new Vector2 (moveInput.x*runSpeed, myRigidbody.velocity.y);
            myRigidbody.velocity = playerVelocity; 
        }
        else
        {
            if(knockedFromRight)
            {
                Vector2 playerVelocity = new Vector2 (-knockbackVelocity, knockbackVelocity);
                myRigidbody.velocity = playerVelocity; 
            }
            else
            {
                Vector2 playerVelocity = new Vector2 (knockbackVelocity, knockbackVelocity);
                myRigidbody.velocity = playerVelocity; 
            }

            knockbackTimer -= Time.deltaTime;
        }
    }

    void FlipSprite()
    {
        if(moveInput.x > 0.01f)
            transform.localScale = Vector3.one;
        else if (moveInput.x < -0.01f)
            transform.localScale = new Vector3(-1,1,1);
    }

    private bool isGrounded()/// cek apakah di bawah ada ground/platform
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, platformLayer);
        return raycastHit.collider != null;
    }
}
