using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private PlayerController Player;

    public Text Health, Ammo, Armor, Battery, HealthPackages;

    private void Start()
    {
        Player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        UpdateTextFields();
    }

    void UpdateTextFields()
    {
        Armor.text = "Armor: " + Player.currentBodyArmor + " / " + Player.maxBodyArmor;
        Health.text = "Health: " + Player.currentHealth + " / " + Player.maxHealth;
        Ammo.text = "Ammunition: " + Player.currentAmmunition + " / " + Player.maxAmmunition;
        Battery.text = "Flashlight Energy: " + Mathf.RoundToInt(Player.currentBatteries) + " / " + Player.maxBatteries;
        HealthPackages.text = "Health Packages: " + Player.healthPackages + " / " + Player.maxHealthPackages;
        
    }
}
