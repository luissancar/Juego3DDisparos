using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    public float delay = 3f;
    float countDown;
    public float radius = 5f;
    public float fuerzaExplosion = 70f;
    bool exploted = false;

    public GameObject efectoExplosion;

    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0 && !exploted)
        {
            exploted = true;
            Exploted();
        }
        
    }

    private void Exploted()
    {
        Instantiate(efectoExplosion,transform.position,
            transform.rotation);


        Collider[] colliders = Physics.
            OverlapSphere(transform.position, radius);
        foreach ( var rangeObjet in colliders)
        {
            Rigidbody rb = rangeObjet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(fuerzaExplosion * 10,
                    transform.position, radius);
            }
        }
        Destroy(gameObject);
    }
}



















