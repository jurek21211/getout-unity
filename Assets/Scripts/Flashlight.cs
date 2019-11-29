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
        enhanceFlashlight();
    }

    void enhanceFlashlight()
    {
        Light flashlight = GetComponentInChildren<Light>();
        PlayerController player = FindObjectOfType<PlayerController>();

        if (Input.GetKey(KeyCode.F) && player.currentBatteries > 0)
        {
            flashlight.range = enhancedRange;
            cam.orthographicSize = 450;
            player.currentBatteries -= 5 * Time.deltaTime;
        }
        else
        {
            flashlight.range = defaultRange;
            cam.orthographicSize = 300;
        }
    }
}
