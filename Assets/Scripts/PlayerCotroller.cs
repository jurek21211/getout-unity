using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCotroller : MonoBehaviour
{
    public float speed;

    public float health;
    public float batteries;

    Vector3 movement;
    Rigidbody playerRigidbody;


    int floorMask;
    float camRayLength = 100f;

    public GameObject openedDoors;
    public Light flashlight;
    public Camera camera;
    public Text healthText;
    public Text batteriesText;




    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");

        playerRigidbody = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        batteries = Random.Range(20, 80);
        health = Random.Range(50, 100);
        updateTexts();
    }


    private void Update()
    {
        enhanceVision();
        updateTexts();
    }


    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Moving player
        movePlayer(h, v);

        turnToMousePointer();

        if (health <= 0 || transform.position.y < -10)
        {
            Die();
        }

    }

    void movePlayer(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void turnToMousePointer()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            playerRigidbody.MoveRotation(newRotation);

        }
    }

    private void OnTriggerEnter(Collider other)

    {

        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Button"))
        {
            GameObject doors = GameObject.FindGameObjectWithTag("ClosedDoors");

            openedDoors.transform.localScale = doors.transform.localScale;
            Instantiate(openedDoors, doors.transform.position, doors.transform.rotation);
            doors.SetActive(false);
        }

        if (other.gameObject.CompareTag("Batteries"))
        {
            batteries += Random.Range(10, 20);
            Destroy(other.gameObject);
        }
        
    }

    void enhanceVision()
    {

        if (Input.GetKey(KeyCode.F) && batteries > 0)
        {
            flashlight.intensity = 1.5f;
            flashlight.range = 50f;
            flashlight.spotAngle = 25f;
            camera.fieldOfView = 100f;
            batteries -= 4 * (Time.deltaTime);
            updateTexts();

        }
        else
        {
            flashlight.intensity = 0.3f;
            flashlight.range = 20;
            flashlight.spotAngle = 15;
            camera.fieldOfView = 70;
            updateTexts();
        }


    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "MeeleEnemy")
        {

            health -= 5 * (Time.deltaTime);

            playerRigidbody.AddForce(new Vector3(0, 0, 50f));
        }

    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    void updateTexts()
    {
        healthText.text = "HEALTH: " + health;
        batteriesText.text = "BATTEIRES: " + batteries;
    }

}
