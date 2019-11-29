using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batteries : Collectibles
{
    private void Update()
    {
            updatePlayerAsset();
    }
    void updatePlayerAsset()
    {
        int amount = 20;
        PlayerController player = FindObjectOfType<PlayerController>();
        if (picked)
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
