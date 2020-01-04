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

        if (collision.gameObject.tag == "Enemy")
        {
            Enemy target = collision.gameObject.GetComponent<Enemy>();
            target.TakeDamage(50);
        }

        if (collision.gameObject.tag == "Player")
        {
            PlayerController target = collision.gameObject.GetComponent<PlayerController>();
            target.TakeDamage(50);

        }

        Destroy(this.gameObject);
    }


   
}
