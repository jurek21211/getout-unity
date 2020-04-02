using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingSystem : MonoBehaviour
{
    public int playerCurrentLevel, playerExperiencePoints, nextLevelExperiencePoints, enemiesCurrentLevel, playerSkillPoints;
    public PlayerController player;
    public GameController gameController { get; set; }


    public void Awake()
    {
        player = FindObjectOfType<PlayerController>();

    }

    public void Start()
    {
        gameController = FindObjectOfType<GameController>();
        playerCurrentLevel = 1;
        enemiesCurrentLevel = gameController.waveNumber; //wave number


        UpdatePlayerStats();
        InitiatePlayerStats();
        SetNewExperiencePointsGoal();

    }

    public void Update()
    {
        if (playerExperiencePoints >= nextLevelExperiencePoints)
        {
            LevelPlayerUP();
        }

        if (enemiesCurrentLevel != gameController.waveNumber)
        {
            UpdateEnemiesLevel();
        }
    }

    public void AddPointsForKill(int amount)
    {
        playerExperiencePoints += amount;

    }

    void LevelPlayerUP()
    {

        playerCurrentLevel += 1;
        UpdatePlayerStats();
        SetNewExperiencePointsGoal();
        playerSkillPoints += 1;

    }
    void SetNewExperiencePointsGoal()
    {

        if (playerCurrentLevel < 5)
        {
            nextLevelExperiencePoints += playerCurrentLevel * 100;
        }
        else
        {
            nextLevelExperiencePoints += (int)Mathf.Pow(playerCurrentLevel, 2f) * 25;
        }


    }

    void UpdatePlayerStats()
    {
        player.maxHealth = (playerCurrentLevel + 5) * 50;
        player.maxAmmunition = (playerCurrentLevel * 10) + 50;
        player.maxBatteries = playerCurrentLevel * 25;
        player.maxBodyArmor = player.maxHealth / 2;
        player.maxHealthPackages = playerCurrentLevel * 2;
    }

    void InitiatePlayerStats()
    {
        player.currentHealth = player.maxHealth;
        player.currentAmmunition = player.maxAmmunition;
        player.currentBodyArmor = player.maxBodyArmor;
        player.currentBatteries = player.maxBatteries;
        player.healthPackages = player.maxHealthPackages;
    }

    void UpdateEnemiesLevel()
    {
        enemiesCurrentLevel = gameController.waveNumber;
    }

    void InitiateEnemiesLevel() { }


}
