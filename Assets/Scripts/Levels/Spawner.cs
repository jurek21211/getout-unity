using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public LevelingSystem levelingSystem;
    public Vector3 planeSize, spawnCords;
    public float xScale, zScale, xBoundry, zBoundry;
    public Enemy cyberSoldier, attackBot;
    public GameObject obstacle1, obstacle2, spawnPoint;

    public LayerMask obstaclesLayer, enemiesLayer;


    private void Awake()
    {
        levelingSystem = FindObjectOfType<LevelingSystem>();
        GameObject plane = GameObject.FindGameObjectWithTag("LevelFloor");
        planeSize = plane.GetComponent<MeshRenderer>().bounds.size;
        xScale = GameObject.FindGameObjectWithTag("LevelBase").transform.localScale.x;
        zScale = GameObject.FindGameObjectWithTag("LevelBase").transform.localScale.z;

        xBoundry = (planeSize.x / 2) - (250 * xScale);
        zBoundry = (planeSize.z / 2) - (250 * zScale);


        Debug.Log(planeSize.x * -1);


    }
    public Vector3 SetSpawnCords()
    {
        return new Vector3(Random.Range(-xBoundry, xBoundry), 2, Random.Range(-zBoundry, zBoundry));
    }


    public void CreateSpawnPoints()
    {
        Instantiate(spawnPoint,
            new Vector3(Random.Range(-xBoundry, -xBoundry * 0.6f), 2, Random.Range(zBoundry, zBoundry * 0.6f)),
            Quaternion.identity); // (1,1)

        Instantiate(spawnPoint,
            new Vector3(Random.Range(-xBoundry * 0.2f, xBoundry * 0.2f), 2, Random.Range(zBoundry, zBoundry * 0.6f)),
            Quaternion.identity); //(3,1)

        Instantiate(spawnPoint,
            new Vector3(Random.Range(xBoundry * 0.6f, xBoundry), 2, Random.Range(zBoundry, zBoundry * 0.6f)),
            Quaternion.identity); //(5,1)

        Instantiate(spawnPoint,
            new Vector3(Random.Range(-xBoundry, -xBoundry * 0.6f), 2, Random.Range(-zBoundry * 0.2f, zBoundry * 0.2f)),
            Quaternion.identity);  //(1,3)

        Instantiate(spawnPoint,
            new Vector3(Random.Range(xBoundry * 0.6f, xBoundry), 2, Random.Range(-zBoundry * 0.2f, zBoundry * 0.2f)),
            Quaternion.identity);  //( 5,3)

        Instantiate(spawnPoint,
            new Vector3(Random.Range(-xBoundry, -xBoundry * 0.6f), 2, Random.Range(-zBoundry, -zBoundry * 0.6f)),
            Quaternion.identity); //(1,5)

        Instantiate(spawnPoint,
            new Vector3(Random.Range(-xBoundry * 0.2f, xBoundry * 0.2f), 2, Random.Range(-zBoundry, -zBoundry * 0.6f)),
            Quaternion.identity); //(3,5)

        Instantiate(spawnPoint,
            new Vector3(Random.Range(xBoundry * 0.6f, xBoundry), 2, Random.Range(-zBoundry, -zBoundry * 0.6f)),
            Quaternion.identity); //(5,5)
    }


    public void SpawnEnemies(int numberOfEnemies, GameObject[] spawnPoints)
    {
        int spawnIdx = 0;
        int enemiesToSpawn = numberOfEnemies;
        Vector3 offset; //offset of an enemy position related to spawn point position

        while (enemiesToSpawn > 0)
        {
            offset = new Vector3(Random.Range(-250f, 250f), 0, Random.Range(-250f, 250f));

            while (Physics.OverlapSphere(spawnPoints[spawnIdx].transform.position + offset, 200, obstaclesLayer).Length != 0
                && Physics.OverlapSphere(spawnPoints[spawnIdx].transform.position + offset, 200, enemiesLayer).Length != 0)
            {
                offset = new Vector3(Random.Range(-250f, 250f), 0, Random.Range(-250f, 250f));
            }

            if (Random.Range(-1.0f, 1.0f) > 0)
            {
                Instantiate(cyberSoldier, spawnPoints[spawnIdx].transform.position + offset, Quaternion.identity);
            }
            else
            {
                Instantiate(attackBot, spawnPoints[spawnIdx].transform.position + offset, Quaternion.identity);
            }
            spawnIdx += 1;
            enemiesToSpawn -= 1;

            if (spawnIdx > (spawnPoints.Length - 1) && enemiesToSpawn > 0)
                spawnIdx = 0;
        }
    }

    public void SpawnObstacles(int numberofObstacles, GameObject[] spawnPoints)
    {
        int spawnIdx = 0;
        int obstaclesToSpawn = numberofObstacles;
        Vector3 offset; //offset of an enemy position related to spawn point position


        while (obstaclesToSpawn > 0)
        {
            offset = new Vector3(Random.Range(-250f, 250f), 0, Random.Range(-250f, 250f));

            //setting new offset for new obstacle, so they dont overlap each other
            while (Physics.OverlapSphere(spawnPoints[spawnIdx].transform.position + offset, 200, obstaclesLayer).Length != 0)
            {
                offset = new Vector3(Random.Range(-250f, 250f), 0, Random.Range(-250f, 250f));
            }

            float scale = Random.Range(0.5f, 1.5f);
            Debug.Log(scale);

            if (Random.Range(-1.0f, 1.0f) > 0)
            {
                GameObject clone = Instantiate(obstacle1,
                    spawnPoints[spawnIdx].transform.position + offset,
                    Quaternion.Euler(0, Random.Range(0f, 180f), 0f));

                clone.transform.localScale = new Vector3(clone.transform.localScale.x * scale,
                                                   clone.transform.localScale.y * scale,
                                                   clone.transform.localScale.z * scale);
            }
            else
            {
                GameObject clone = Instantiate(obstacle2,
                    spawnPoints[spawnIdx].transform.position + offset,
                    Quaternion.Euler(0, Random.Range(0f, 180f), 0f));

                clone.transform.localScale = new Vector3(clone.transform.localScale.x * scale,
                                                   clone.transform.localScale.y * scale,
                                                   clone.transform.localScale.z * scale);
            }
            obstaclesToSpawn -= 1;
            spawnIdx += 1;

            if (spawnIdx > (spawnPoints.Length - 1) && obstaclesToSpawn > 0)
                spawnIdx = 0;
        }
    }


}
