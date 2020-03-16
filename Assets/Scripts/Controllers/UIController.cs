using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private PlayerController Player;
    private LevelingSystem levelingSystem { get; set; }

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI, deathMenuUI;
    public GameController gameController;


    public Text Health, Ammo, Armor, Battery, HealthPackages, Wave, PlayerLevel, PlayerExp, NextLevelExp, EnemiesLeft, GetReadyText;



    private void Start()
    {
        Player = FindObjectOfType<PlayerController>();
        Time.timeScale = 1f;
        levelingSystem = FindObjectOfType<LevelingSystem>();
    }

    private void LateUpdate()
    {
        UpdateTextFields();

        if (Input.GetKeyDown(KeyCode.Escape) && deathMenuUI.activeSelf == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Player.isAlive == false)
        {
            DeathMenu();
        }

        if ( gameController.enemiesToKill == 0)
        {
            GetReadyText.gameObject.SetActive(true);
        }
        else
        {
            GetReadyText.gameObject.SetActive(false);
        }

    }

    void UpdateTextFields()
    {
        Armor.text = "Armor: " + Player.currentBodyArmor + " / " + Player.maxBodyArmor;
        Health.text = "Health: " + Player.currentHealth + " / " + Player.maxHealth;
        Ammo.text = "Ammunition: " + Player.currentAmmunition + " / " + Player.maxAmmunition;
        Battery.text = "Flashlight Energy: " + Mathf.RoundToInt(Player.currentBatteries) + " / " + Player.maxBatteries;
        HealthPackages.text = "Health Packages: " + Player.healthPackages + " / " + Player.maxHealthPackages;
        Wave.text = "Wave: " + gameController.waveNumber;
        PlayerLevel.text = "Level: " + levelingSystem.playerCurrentLevel;
        PlayerExp.text = "EXP Points: " + levelingSystem.playerExperiencePoints;
        NextLevelExp.text = "Next Level: " + levelingSystem.nextLevelExperiencePoints;
        EnemiesLeft.text = "Enemies Left: " + gameController.enemiesToKill;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void DeathMenu()
    {
        Time.timeScale = 0f;
        deathMenuUI.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

