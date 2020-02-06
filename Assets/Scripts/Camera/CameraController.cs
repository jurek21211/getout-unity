using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    public float smoothness;

    Vector3 cameraOffset;

    private void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        cameraOffset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + cameraOffset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothness * Time.deltaTime);
    }
}

