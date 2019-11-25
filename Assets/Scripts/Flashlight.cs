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

        if (Input.GetKey(KeyCode.F))
        {
            flashlight.range = enhancedRange;
            cam.orthographicSize = 450;
        }
        else
        {
            flashlight.range = defaultRange;
            cam.orthographicSize = 300;
        }
    }
}
