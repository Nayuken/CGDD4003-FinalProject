using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float rotateY;
    public float speed = 6f;

    private float horizontal;
    private float vertical;
    private float steerAngle;
    private bool isBreaking;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;
    public float motorForce = 50f;
    public float brakeForce = 0f;

    Rigidbody playerRigidBody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;
    public PowerupDisplay HUD;

    public int total;
    public Text score;

    public bool isDead = false;
    public GameObject gameOver;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        HUD.Stable();
        total = 0;
    }

    void Update()
    {
        score.text = " x " + total;
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(1);
            print("Player Health: " + currentHealth);
        }
        if (currentHealth == 0)
        {
            isDead = true;
        }
        if (total == 5)
        {
            gameOver.SetActive(true);
        }
    }


    void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();

        /*float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rotateY += horizontal * 5;
        if (rotateY > 360)
        {
            rotateY -= 360;
        }
        if(rotateY < -360)
        {
            rotateY += 360;
        }
        transform.rotation = Quaternion.Euler(0, rotateY, 0);
        if (vertical != 0)
        {
            Vector3 velocity = transform.forward * speed * Time.deltaTime * vertical;
            playerRigidBody.MovePosition(transform.position + velocity);
        }*/
    }

    private void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontal;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = vertical * motorForce;
        frontRightWheelCollider.motorTorque = vertical * motorForce;

        brakeForce = isBreaking ? 3000f : 0f;
        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
