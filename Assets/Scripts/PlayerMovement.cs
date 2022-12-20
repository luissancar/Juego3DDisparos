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


    
    void Update()
    {
        // Movimiento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move=transform.right*x+transform.forward*z;
        characterController.Move(move * speed * Time.deltaTime);

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

    }
}
