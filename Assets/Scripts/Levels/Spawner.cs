using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Vector3 planeSize, spawnCords;
    public float xScale, zScale, xBoundry, zBoundry;
    public Enemy cyberSoldier, attackBot;


    private void Start()
    {
        GameObject plane = GameObject.FindGameObjectWithTag("LevelFloor");
        planeSize = plane.GetComponent<MeshRenderer>().bounds.size;
        xScale = GameObject.FindGameObjectWithTag("LevelBase").transform.localScale.x;
        zScale = GameObject.FindGameObjectWithTag("LevelBase").transform.localScale.z;

        xBoundry = (planeSize.x / 2) - (250 * xScale);
        zBoundry = (planeSize.z / 2) - (250 * zScale);


        Debug.Log(planeSize.x * -1);

        spawnEnemies();
    }
    public Vector3 SetSpawnCords()
    {
        return new Vector3(Random.Range(-xBoundry, xBoundry), 3, Random.Range(-zBoundry, zBoundry));
    }

   void spawnEnemies()
    {
        for (int i = 0; i < 20; i++)
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
}
