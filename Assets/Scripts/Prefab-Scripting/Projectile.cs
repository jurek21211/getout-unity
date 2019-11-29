using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    Rigidbody projectileRgbd;
    public float damage;

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
            Enemy target = FindObjectOfType<Enemy>();
            target.TakeDamage(20);
        }

        Destroy(this.gameObject);
    }


   
}
