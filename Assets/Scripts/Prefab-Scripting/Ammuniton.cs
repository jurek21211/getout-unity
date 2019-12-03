using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammuniton : Collectibles
{
    private void Update()
    {
        updatePlayerAsset();
    }
    void updatePlayerAsset()
    {
        int amount = 20;
        PlayerController player = FindObjectOfType<PlayerController>();
        if (picked && player.currentAmmunition < player.maxAmmunition)
        {
            if ((player.maxAmmunition - player.currentAmmunition) < amount)
            {
                player.currentAmmunition = player.maxAmmunition;
            }
            else
            {
                player.currentAmmunition += amount;
            }
            Die();
        }
    }
}
