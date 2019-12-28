using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Collectibles
{
    void Update()
    {
        updatePlayerAsset();
    }

    void updatePlayerAsset()
    {
        int amount = 15;

        PlayerController player = FindObjectOfType<PlayerController>();
        
        if (picked && player.currentBodyArmor < player.maxBodyArmor)
        {
            if ((player.maxBodyArmor - player.currentBodyArmor) < amount)
            {
                player.currentBodyArmor = player.maxBodyArmor;
            }
            else
            {
                player.currentBodyArmor += amount;
            }
            Die();
        }
    }
}
