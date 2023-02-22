using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public Transform plr;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public float speed = 2f;
    public float health = 1;
    public float Health
    {
        set
        {
            health = value;

            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }
    public void Update()
    {
        ChargeToPlayer();
    }


    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    public void Defeated()
    {
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
    public void ChargeToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, plr.position, speed * Time.deltaTime);
    }
}
