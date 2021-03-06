﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Rigidbody projectileRgbd;
    [Range(10,50)]
    public int damage;

    private LevelingSystem levelingSystem;

    private void Awake()
    {
        levelingSystem = FindObjectOfType<LevelingSystem>();
    }

    void Start()

    {
        projectileRgbd = GetComponent<Rigidbody>();
    }


    void Update()
    {
        projectileRgbd.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("PlayerProjectile"))
        {
            Enemy target = collision.gameObject.GetComponent<Enemy>();
            target.TakeDamage(damage * levelingSystem.playerCurrentLevel);
        }

        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("EnemyProjectile"))
        {
            PlayerController target = collision.gameObject.GetComponent<PlayerController>();
            target.TakeDamage(damage * levelingSystem.enemiesCurrentLevel );

        }


        Destroy(this.gameObject);
    }



}
