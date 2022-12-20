using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{


    public NavMeshAgent agent;
    public Transform destino;
    public Transform destino2;
    private Transform destinoActual;

    // Start is called before the first frame update
    void Start()
    {
        destinoActual = destino;
        agent.destination = destinoActual.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, destino.transform.position);
        if (distancia < 3)
        {
            destinoActual = destino2;
            Debug.Log(1);
        }

        distancia = Vector3.Distance(transform.position, destino2.transform.position);
        if (distancia < 3)
        {
            destinoActual = destino;
            Debug.Log(2);
        }

        agent.destination = destinoActual.transform.position;


    }
}
