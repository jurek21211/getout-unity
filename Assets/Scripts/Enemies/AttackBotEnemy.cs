using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackBotEnemy : Enemy
{
    public float fireRate, stopDistance;

    public GameObject shot, shotSpawnL, shotSpawnR;
    private NavMeshAgent agent;

    private float nextFire;
    private Vector3 startPosition;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerController>();
        startPosition = transform.position;
    }
    private void FixedUpdate()
    {
        ChasePlayer(player);
    }
    private void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawnL.transform.position, shotSpawnL.transform.rotation);
            Instantiate(shot, shotSpawnR.transform.position, shotSpawnR.transform.rotation);

        }

    }

    private void ChasePlayer(PlayerController target)
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance < lookRadius)
        {
            Shoot();
            FaceTarget(player);
            agent.SetDestination(target.transform.position);
        }

       if (distance <= stopDistance)
        {
            agent.SetDestination(transform.position);

        }

        if (distance > abandonDistance)
        {
            agent.SetDestination(startPosition);

            transform.LookAt(startPosition);
        }
    }
}
