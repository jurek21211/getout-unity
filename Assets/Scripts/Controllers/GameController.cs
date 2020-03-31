using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int waveNumber { get; set; }
    public int playerKillCount { get; set; }
    public int enemiesToKill { get; set; }

    [Range(0, 60)]
    public int newWaveCooldown;

    public GameObject[] spawnPoints { get; set; }

    public Spawner spawner;

    private Time time;

    private int numberOfObstacles;
    public bool onGoingWave;



    private void Start()
    {
        numberOfObstacles = Random.Range(8, 16);
        waveNumber = 1;
        GenerateLevel();
        enemiesToKill = 10 + waveNumber * 2;
        SpawnWave();
        onGoingWave = true;
    }

    private void LateUpdate()
    {
        if (enemiesToKill == 0)
            onGoingWave = false;



        StartCoroutine(StartNewWave());

    }

    void GenerateLevel()
    {
        spawner.CreateSpawnPoints();
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawner.SpawnObstacles(numberOfObstacles, spawnPoints);

    }

    void SpawnWave()
    {
        spawner.SpawnEnemies(enemiesToKill, spawnPoints);
    }

    IEnumerator StartNewWave()
    {
        if (onGoingWave == false)
            yield return new WaitForSeconds(newWaveCooldown);

        if (enemiesToKill == 0)
        {

            waveNumber += 1;

            int newEnemiesToKill = 10 + waveNumber * 2;
            enemiesToKill = newEnemiesToKill;
            SpawnWave();

            onGoingWave = true;
        }
    }


}
