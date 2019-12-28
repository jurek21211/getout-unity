using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackage : Collectibles
{
    public int healingValue;

    private void Start()
    {
        healingValue = Random.Range(25, 40);
    }
    private void Update()
    {
        updatePlayerAsset();

    }
    void updatePlayerAsset()
    {
        int amount = 1;
        PlayerController player = FindObjectOfType<PlayerController>();
        if (picked && player.maxHealthPackages > player.healthPackages)
        {
            if ((player.maxHealthPackages - player.healthPackages) < amount)
            {
                player.healthPackages = player.maxHealthPackages;
            }
            else
            {
                player.healthPackages += amount;
            }
            Die();
        }
    }

}
