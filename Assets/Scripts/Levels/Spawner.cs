using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public LevelingSystem levelingSystem;
    public Vector3 planeSize, spawnCords;
    public float xScale, zScale, xBoundry, zBoundry;
    public Enemy cyberSoldier, attackBot;
    public GameObject obstacle;

   

    private void Start()
    {
        levelingSystem = FindObjectOfType<LevelingSystem>();
        GameObject plane = GameObject.FindGameObjectWithTag("LevelFloor");
        planeSize = plane.GetComponent<MeshRenderer>().bounds.size;
        xScale = GameObject.FindGameObjectWithTag("LevelBase").transform.localScale.x;
        zScale = GameObject.FindGameObjectWithTag("LevelBase").transform.localScale.z;

        xBoundry = (planeSize.x / 2) - (250 * xScale);
        zBoundry = (planeSize.z / 2) - (250 * zScale);


        Debug.Log(planeSize.x * -1);
        SpawnObstacles();

        SpawnEnemies();
        

    }
    public Vector3 SetSpawnCords()
    {
        return new Vector3(Random.Range(-xBoundry, xBoundry), 3, Random.Range(-zBoundry, zBoundry));
    }

   void SpawnEnemies()
    {
        for (int i = 0; i < 15; i++)
        {
            spawnCords = SetSpawnCords();
            
            if (Random.Range(-1.0f, 1.0f) > 0)
            {
                Instantiate(cyberSoldier, spawnCords, Quaternion.identity);
            }
            else
            {
                Instantiate(attackBot, spawnCords, Quaternion.identity);
            }
        }
    }

    void SpawnObstacles()
    {
      
    }

    void SpawnCollectibles()
    {

    }
}
