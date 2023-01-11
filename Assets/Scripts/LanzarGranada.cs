using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarGranada : MonoBehaviour
{
    public float fuerzaLanzar = 550f;
    public GameObject granadaPrefab;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Lanzar();
        }
        
    }

    private void Lanzar()
    {
        GameObject nuevaGranada = Instantiate
          (granadaPrefab,transform.position,transform.rotation);
        nuevaGranada.GetComponent<Rigidbody>().AddForce
            (transform.forward * fuerzaLanzar);
    }
}
