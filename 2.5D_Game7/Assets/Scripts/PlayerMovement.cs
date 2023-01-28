using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{  
    public Animator animator;
    private float speed = 3.5f;

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        movement.Normalize();
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            print("AYAYA");
        }
    }

    //private void OnTriggerEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Wall")
    //    {

    //    }
    //}


}

// public float speed = 5f;
// private new Rigidbody2D rigidbody;
// public float health = 10;

// private Vector2 moveInput;
// private Vector2 moveVelocity;
// private Animator animator;

// public GameObject Sword;
// public GameObject Gun;

// private bool facingRight = true;


// void Start()
// {
//     rigidbody = GetComponent<Rigidbody2D>();
//     animator = GetComponent<Animator>();
// }
// // Update is called once per frame
// void Update()
// {

//     moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

//     moveVelocity = moveInput.normalized * speed;
//     if (!facingRight && moveInput.x > 0)
//     {
//         Flip();
//     }
//     else if (facingRight && moveInput.x < 0)
//     {
//         Flip();
//     }
//    /* Animations();*/

//     if (health <= 0)
//     {
//         Destroy(gameObject);
//     }
// }

// private void FixedUpdate()
// {
//     rigidbody.MovePosition(rigidbody.position + moveVelocity * Time.fixedDeltaTime);
// }
///* public void Animations()
// {
//     if (moveInput.magnitude == 0)
//     {
//         animator.SetBool("isWalk", false);
//     }
//     else
//     {
//         animator.SetBool("isWalk", true);
//         if (Input.GetKey(KeyCode.LeftShift) == true)
//         {
//             animator.SetBool("isRunning", true);
//         }
//         else
//         {
//             animator.SetBool("isRunning", false);
//         }
//     }

// }*/


// private void Flip()
// {
//     facingRight = !facingRight;
//     Vector3 Scaler = transform.localScale;
//     Scaler.x *= -1;
//     transform.localScale = Scaler;
// }