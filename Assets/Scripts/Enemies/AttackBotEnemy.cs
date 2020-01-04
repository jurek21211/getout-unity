using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBotEnemy : Enemy
{
    private void FixedUpdate()
    {
        Shoot();
        ChasePlayer(player);
    }
    private void Shoot()
    {
        Debug.Log("Enemy Shot");
    }

    void ChasePlayer(PlayerController target)
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if (distance < lookRadius)
        {
            faceTarget(player);
            
        }
        if (distance > lookRadius / 2 && distance < lookRadius)
        {
            agent.SetDestination(target.transform.position);
        }
        if (distance < lookRadius / 2)
        {
            agent.SetDestination(transform.position);
        }
    }
}
