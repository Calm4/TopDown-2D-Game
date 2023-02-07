using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 100f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;
    public float x, y;
    private bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        rb.velocity = movementInput * moveSpeed * Time.fixedDeltaTime;
    }
    private void Update()
    {
        if (canMove)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            if (x != 0 || y != 0)
            {
                animator.SetFloat("X", x);
                animator.SetFloat("Y", y);
                if (!isWalking)
                {
                    isWalking = true;
                    animator.SetBool("isMoving",isWalking);
                }

            }
            else
            {
                if (isWalking)
                {
                    isWalking = false;
                    animator.SetBool("isMoving", isWalking);
                    
                }
            }
        }
        movementInput = new Vector3(x,y).normalized;
    }
  
    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
