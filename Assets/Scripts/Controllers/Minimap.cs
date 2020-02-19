using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject mapBorder, mapImage;

    private void LateUpdate()
    {
        Vector3 newPosition = playerTransform.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        bool mapOpened = Input.GetKey(KeyCode.M);

        mapBorder.SetActive(mapOpened);
        mapImage.SetActive(mapOpened);


    }
}
