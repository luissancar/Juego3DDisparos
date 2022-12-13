using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemeraLook : MonoBehaviour
{
    public float mouseSensitivity = 80f;
    public Transform playerBody;
    float xRotation = 0;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.Euler(7.95f, 0f,0f);
        
    }

   
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation-=mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}














