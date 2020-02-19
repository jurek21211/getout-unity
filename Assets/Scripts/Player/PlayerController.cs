using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(150, 400)]
    public float speed;
    [Range(10, 20)]
    public float dashSpeed;
    [Range(0, 10)]
    public float dashCooldownLimit;

    
    [Range(0, 3)]
    public float fireRate;

    public float dashCooldown;


    public int maxHealth { get; set; }
    public int currentHealth { get; set; }
    public float maxBatteries { get; set; }
    public float currentBatteries { get; set; }
    public int maxAmmunition { get; set; }
    public int currentAmmunition { get; set; }
    public int maxBodyArmor { get; set; }
    public int currentBodyArmor { get; set; }

    public int maxHealthPackages { get; set; }
    public int healthPackages { get; set; }


    public GameObject shot;
    public Transform shotSpawn;

    Vector3 movementVector;
    Animator animationController;
    Rigidbody playerRigidbody;
    int floorMask;
    readonly float camRayLength = 1000f;
    float nextFire;


    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");

        animationController = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

    }


    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float dash = Input.GetAxis("Jump");
        float shoot = Input.GetAxis("Fire1");
        MovePlayer(horizontal, vertical, dash);
        AnimatePlayer(horizontal, vertical, shoot);
        TurnToMousePointer();
        WaitForCooldown();
        Shoot(shoot);
        UseHealthPackage();
    }

    void MovePlayer(float h, float v, float dash)
    {

        movementVector.Set(h, 0f, v);

        movementVector = movementVector.normalized * speed * Time.deltaTime;

        if (dash != 0 && dashCooldown == dashCooldownLimit)
        {
            movementVector *= dashSpeed;
            dashCooldown = 0;
        }

        playerRigidbody.MovePosition(transform.position + movementVector);
    }



    void AnimatePlayer(float h, float v, float fire)
    {
        bool walking = v != 0f || h != 0;
        bool shooting = fire != 0f && currentAmmunition > 0;
        animationController.SetBool("IsWalking", walking);
        animationController.SetBool("Shooting", shooting);

    }

    void TurnToMousePointer()
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

    private void WaitForCooldown()
    {
        if (dashCooldown < dashCooldownLimit)
        {
            dashCooldown += 1 * Time.deltaTime;
        }
        else
        {
            dashCooldown = dashCooldownLimit;
        }
    }

    void Shoot(float shoot)
    {
        if (shoot != 0 && Time.time > nextFire && currentAmmunition > 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            currentAmmunition -= 1;

        }

    }
    void UseHealthPackage()
    {
        int healingValue = 20;
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (healthPackages > 0 && currentHealth < maxHealth)
            {
                if ((maxHealth - currentHealth < healingValue))
                {
                    currentHealth = maxHealth;
                    healthPackages -= 1;
                }
                else
                {
                    currentHealth += healingValue;
                    healthPackages -= 1;
                }
            }
        }
    }

    public void TakeDamage(int amount)
    {
        if (currentBodyArmor > 0)
        {
            currentHealth -= (amount / 2);
            currentBodyArmor -= ((amount / 4) * 3);
            if (currentBodyArmor < 0)
            {
                currentBodyArmor = 0;
            }
        }
        else
        {
            currentHealth -= amount;
        }
    }
}