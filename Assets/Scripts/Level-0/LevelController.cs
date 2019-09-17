using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    public GUIText ammoInfo;
    public int ammo;
    public GameObject doorButton;
    public GameObject gameOverText;
    public GameObject player;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        ammo = Random.Range(3,10);
    }

    // Update is called once per frame
    void Update()
    {
        gameOver();
    }

    void gameOver()
    {
        if (player == null || enemy == null)
        {
            gameOverText.SetActive(true);
            Invoke("Restart", 3);
        }
        
     }


    void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

} 
