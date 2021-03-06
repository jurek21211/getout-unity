﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    protected bool picked = false;

    public LevelingSystem levelingSystem { get; set; }

    private void Awake()
    {
        levelingSystem = FindObjectOfType<LevelingSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            picked = true;
        else
            picked = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            picked = false;
    }
    protected void Die()
    {
        Destroy(gameObject);
    }
}
