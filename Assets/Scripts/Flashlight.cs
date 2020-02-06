using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public float enhancedRange;
    public float defaultRange;


    public Camera cam;

    void Update()
    {
        EnhanceFlashlight();
    }

    void EnhanceFlashlight()
    {
        Light flashlight = GetComponentInChildren<Light>();
        PlayerController player = FindObjectOfType<PlayerController>();

        if (Input.GetKey(KeyCode.F) && player.currentBatteries > 0)
        {
            flashlight.range = enhancedRange;
            cam.orthographicSize = 800;
            player.currentBatteries -= 5 * Time.deltaTime;
        }
        else
        {
            flashlight.range = defaultRange;
            cam.orthographicSize = 500;
        }
    }
}
