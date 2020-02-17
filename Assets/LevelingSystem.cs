using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingSystem : MonoBehaviour
{
    public int playerCurrentLevel, playerExperiencePoints, nextLevelExperiencePoints, enemiesCurrentLevel, playerSkillPoints;
    public PlayerController player;


    public void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void Start()
    {
        playerCurrentLevel = 1;
        enemiesCurrentLevel = playerCurrentLevel;

        
        UpdatePlayerStats();
        InitiatePlayerStats();

    }

   public void AddPointsForKill(int amount)
    {
        playerExperiencePoints += amount;
    }

    void LevelPlayerUP()
    {
        
    }
    void SetNewExperiencePointsGoal() { }

    void UpdatePlayerStats() {
        player.maxHealth = (playerCurrentLevel + 5) * 50;
        player.maxAmmunition = (playerCurrentLevel * 10) + 50;
        player.maxBatteries = playerCurrentLevel * 25;
        player.maxBodyArmor = player.maxHealth / 2;
        player.maxHealthPackages = playerCurrentLevel * 2;
    }

    void InitiatePlayerStats() {
        


        player.currentHealth = player.maxHealth;
        player.currentAmmunition = player.maxAmmunition;
        player.currentBodyArmor = player.maxBodyArmor;
        player.currentBatteries = player.maxBatteries;
        player.healthPackages = player.maxHealthPackages;



    }

    void UpdateEnemiesLevel() { }

    void InitiateEnemiesLevel() { }


}
