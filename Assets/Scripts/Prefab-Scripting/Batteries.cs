using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batteries : Collectibles
{
    private void Update()
    {
            UpdatePlayerAsset();
    }
    void UpdatePlayerAsset()
    {
        int amount = 20;
        PlayerController player = FindObjectOfType<PlayerController>();
        if (picked && player.currentBatteries < player.maxBatteries)
        {
            if ((player.maxBatteries - player.currentBatteries) < amount)
            {
                player.currentBatteries = player.maxBatteries;
            }
            else
            {
                player.currentBatteries += amount;
            }
            Die();
        }
    }

   
}
