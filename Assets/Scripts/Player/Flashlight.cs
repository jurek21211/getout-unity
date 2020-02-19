using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Range(0,2000)]
    public float enhancedRange;
    [Range(0,2000)]
    public float defaultRange;
    [Range(0,2000)]
    public float camSize;
    [Range(0,2000)]
    public float camEnhancedSize;


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
            cam.orthographicSize = camEnhancedSize;
            player.currentBatteries -= 5 * Time.deltaTime;
        }
        else
        {
            flashlight.range = defaultRange;
            cam.orthographicSize = camSize;
        }
    }
}
