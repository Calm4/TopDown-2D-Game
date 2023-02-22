using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody;   
    public Animator animator;

    public float moveSpeed = 1f;

    public float x;
    public float y;
    private bool isWalking;

    //public float collisionOffset = 0.05f;
    //Vector2 movementInput;
    private Vector2 moveDirection;



    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
        Animations();

    }
    private void FixedUpdate()
    {
        rigidbody.velocity = moveDirection * moveSpeed;
    }
    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(x, y);
        moveDirection.Normalize();
    }
    void Animations()
    {
        if (moveDirection.magnitude > 0.1f || moveDirection.magnitude < -0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if (isWalking)
        {
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
        }
        animator.SetBool("isMoving",isWalking);
    }
    void StopMoving()
    {
        rigidbody.velocity = new Vector2(0, 0);
    }
    // Проверка которая позволяет сразу нажимать к примеру A и W что бы перс двигался а не замирал и упирался в стену  
    /*void StabilizationMovementDiagonally()
    {
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);
            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));
                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }
        }
    }
    private bool TryMove(Vector2 direction)
    {
        int count = rigidbody.Cast(direction, movementFilter, castCollision, moveSpeed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0)
        {
            rigidbody.MovePosition(rigidbody.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }*/

}
