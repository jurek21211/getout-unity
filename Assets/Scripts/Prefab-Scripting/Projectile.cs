using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    Rigidbody projectileRgbd;
    public int damage;

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
            target.TakeDamage(damage);
        }

        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("EnemyProjectile"))
        {
            PlayerController target = collision.gameObject.GetComponent<PlayerController>();
            target.TakeDamage(damage);

        }

        if (transform.position.x > 1000 || transform.position.z > 1000)
        {
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }


   
}
