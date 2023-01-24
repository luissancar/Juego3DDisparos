using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;

    // Gravedad
    public float gravity = -9.8f;
    Vector3 velocity;

    //Salto
    public float jumpHeight = 300f;

    //GroundCheck
    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    bool isGrounded;


    //Run
    public bool isSprinting;
    public float sprintingSpeedMultiplier = 5f;
    public float sprintSpeed = 1f;


    public float staminaUseAmount = 5;
    private Slide staminaSlider;


    private void Start()
    {
        staminaSlider=FindObjectOfType<Slide>();
    }

    void Update()
    {
        // Movimiento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move=transform.right*x+transform.forward*z;
        characterController.Move(move * speed * Time.deltaTime
            *sprintSpeed);

        // Gravedad
        velocity.y +=gravity*Time.deltaTime;
        characterController.Move(velocity*Time.deltaTime);
        //GroundCheck
        isGrounded=Physics.CheckSphere(groundCheck.position,sphereRadius,groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
        //Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity * Time.deltaTime);
            Debug.Log("salto");
        }
        RunCheck();

    }

    private void RunCheck()
    {
       
        if (Input.GetKeyDown(KeyCode.S))
        {
            isSprinting=!isSprinting;
            if (isSprinting)
            {
                staminaSlider.UseStamina(staminaUseAmount);
            }
            else 
            {
                staminaSlider.UseStamina(0);
            }
        }
        if (isSprinting)
        {
            sprintSpeed = sprintingSpeedMultiplier;
        }
        else
        {
            sprintSpeed = 1f;
        }

    }
}
