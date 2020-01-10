using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public float lookRadius;
    public GameObject armor; //10%
    public GameObject healthPackage; //10%
    public GameObject ammunition; //15%
    public GameObject batteries; // 15%

    public float health;

    protected PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        this.health -= amount;

        if (this.health <= 0f)
        {
            Die();
            GiveExperiencePoints();
            dropItem();
        }
    }

    void GiveExperiencePoints()
    {
        player.currentExperiencePoints += Random.Range(5, 10);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }



    protected void faceTarget(PlayerController target)
    {
        Vector3 direction = (target.transform.position - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 4f);
    }

    void dropItem()
    {
        float itemClass = Random.Range(0, 100);

        if (itemClass > 0 && itemClass < 10)
        {
            Instantiate(armor, new Vector3(transform.position.x, 25, transform.position.z), transform.rotation);
        }
        else if (itemClass > 10 && itemClass < 20)
        {
            Instantiate(healthPackage, new Vector3(transform.position.x, 25, transform.position.z), transform.rotation);
        }
        else if (itemClass > 20 && itemClass < 35)
        {
            Instantiate(batteries, new Vector3(transform.position.x, 25, transform.position.z), transform.rotation);
        }
        else if (itemClass > 35 && itemClass < 50)
        {
            Instantiate(ammunition, new Vector3(transform.position.x, 25, transform.position.z), transform.rotation);
        }
    }

}
