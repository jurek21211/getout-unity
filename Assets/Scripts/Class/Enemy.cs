using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public float lookRadius, abandonDistance;
    public GameObject armor; //15%
    public GameObject healthPackage; //15%
    public GameObject ammunition; //15%
    public GameObject batteries; // 15%

    LevelingSystem levelingSystem;
    public GameObject levelingController;


    public float health;

    public int enemyLevel;

    private int experiencePointsForKill;

    protected PlayerController player;
    

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        enemyLevel = Random.Range(levelingSystem.enemiesCurrentLevel, levelingSystem.enemiesCurrentLevel + 1);
        experiencePointsForKill = enemyLevel * 20;
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
            DropItem();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }



    protected void FaceTarget(PlayerController target)
    {
        Vector3 direction = (target.transform.position - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 4f);
    }

    void DropItem()
    {
        float itemClass = Random.Range(0, 100);

        if (itemClass > 0 && itemClass < 20)
        {
            Instantiate(armor, new Vector3(transform.position.x, 25, transform.position.z), transform.rotation);
        }
        else if (itemClass > 20 && itemClass < 40)
        {
            Instantiate(healthPackage, new Vector3(transform.position.x, 25, transform.position.z), transform.rotation);
        }
        else if (itemClass > 40 && itemClass < 65)
        {
            Instantiate(batteries, new Vector3(transform.position.x, 25, transform.position.z), transform.rotation);
        }
        else if (itemClass > 65 && itemClass < 90)
        {
            Instantiate(ammunition, new Vector3(transform.position.x, 25, transform.position.z), transform.rotation);
        }
    }

}
