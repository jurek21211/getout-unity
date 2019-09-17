using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public int damage;
    public float range = 1f;
    public int ammunition;

    public GameObject gunBarrel;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public void Start()
    {
        ammunition =  Random.Range(20, 35);
    }
    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammunition > 0)
        {
            
            Shoot();
        }
    }

    void Shoot()
    {
        damage = Random.Range(5, 12);
        ammunition -= 1;
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(gunBarrel.transform.position, gunBarrel.transform.up, out hit, range) && ammunition >= 0)
        {
            //Debug.Log(hit.transform.name);

            PracticeTarget target = hit.transform.GetComponent<PracticeTarget>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            MeeleEnemy enemy = hit.transform.GetComponent<MeeleEnemy>();

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
                

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
 
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            ammunition += Random.Range(2, 6);
            Destroy(other.gameObject);
        }
    }
}
