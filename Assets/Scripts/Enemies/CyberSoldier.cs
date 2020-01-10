using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CyberSoldier : Enemy
{

    public float stopDistance;
    private Vector3 startPosition;
    public int damage;
    private bool isMoving, isAttacking;
    private Animator animator;
    private NavMeshAgent agent;
   

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
        
    }

    private void FixedUpdate()
    {
        ChasePlayer(player);
        AnimateCyberSoldier();
    }

    private void ChasePlayer(PlayerController target)
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        float startPointDistance = Vector3.Distance(transform.position, startPosition);

        if (distance < lookRadius)
        {
            faceTarget(player);

            isMoving = true;
            isAttacking = false;
            agent.SetDestination(target.transform.position);
        }

        if (distance <= stopDistance)
        {
            agent.SetDestination(transform.position);
            isMoving = false;
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
        if (distance  > lookRadius)
        {
            agent.SetDestination(startPosition);
            
            transform.LookAt(startPosition);
            if (startPointDistance < 15)
            {
                isMoving = false;
            }
        }

    }




    void AnimateCyberSoldier()
    {
        animator.SetBool("isRunning", isMoving);
        animator.SetBool("isAttacking", isAttacking);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.TakeDamage(damage);
        }
    }
}
