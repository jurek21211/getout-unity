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
    public GameObject deathParticles;

    public LevelingSystem levelingSystem;
    public GameController gameController;



    public int health;


    protected PlayerController player;

    private void Awake()
    {
        levelingSystem = FindObjectOfType<LevelingSystem>();
        gameController = FindObjectOfType<GameController>();
        
    }
    private void Start()
    {
        
        player = FindObjectOfType<PlayerController>();
        health = 100 + levelingSystem.enemiesCurrentLevel * 20;
        
    }
    void Die()
    {   
       
        Destroy(gameObject);
        GameObject clone = Instantiate(deathParticles, transform.position, Quaternion.identity);
        gameController.playerKillCount += 1;
        gameController.enemiesToKill -= 1;

        Destroy(clone, 3f);
    }

    public void TakeDamage(int amount)
    {
        this.health -= amount;

        if (this.health <= 0f)
        {


            levelingSystem.AddPointsForKill(levelingSystem.enemiesCurrentLevel * 50);
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
        else if (itemClass > 40 && itemClass < 55)
        {
            Instantiate(batteries, new Vector3(transform.position.x, 25, transform.position.z), transform.rotation);
        }
        else if (itemClass > 55 && itemClass < 90)
        {
            Instantiate(ammunition, new Vector3(transform.position.x, 25, transform.position.z), transform.rotation);
        }
    }

}
