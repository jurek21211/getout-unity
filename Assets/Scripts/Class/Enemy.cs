using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health;
    void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        this.health -= amount;

        if (this.health <= 0f)
        {
            Die();
            GiveExperiencePoints();
        }
    }

    void GiveExperiencePoints()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.currentExperiencePoints += Random.Range(5, 10);
    }
}
