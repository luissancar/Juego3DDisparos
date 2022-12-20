using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFloor : MonoBehaviour
{
    CharacterController player;

    // Posiciones y nombre del suelo
    Vector3 groundPositon;
    Vector3 LastGroundPositon;
    string groundName;
    string lastGroundName;


    void Start()
    {
        player= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded)
        {
            RaycastHit hit;//crea raycast gordo, para ver si gran parte del player esta tocando suelo

            if (Physics.SphereCast(transform.position,player.height/4.2f,-transform.up,out hit)) // out pasa valor por referencia
            {
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPositon = groundedIn.transform.position;

                if (groundPositon != LastGroundPositon && groundName == lastGroundName) 
                {
                    this.transform.position += groundPositon - LastGroundPositon ;
                    Debug.Log("Mov");
                }

                lastGroundName = groundName;
                LastGroundPositon = groundPositon;
                Debug.Log(groundName);
                Debug.Log(groundPositon);

            }

        }
        else
        {
            // sino al tocasr suelo volveresmos a la antigua posición
            lastGroundName = null;
            LastGroundPositon = Vector3.zero;


        }
        
    }


    private void OnDrawGizmos()  // rear un gizmos líneas de los objetos
    {
        player = this.GetComponent<CharacterController>();  // al ser una FUNCION INDE PENDIENTE Lo repetimas
        Gizmos.DrawWireSphere(transform.position, player.height / 4.2f);
    }

}
