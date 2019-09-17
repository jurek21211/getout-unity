using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public GUIText ammoInfo;
    public int ammo;
    public GameObject doorButton;
    // Start is called before the first frame update
    void Start()
    {
        ammo = Random.Range(3,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateAmmo() => ammoInfo.text = "Ammunition: " + ammo;

} 
