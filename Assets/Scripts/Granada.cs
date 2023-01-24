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

    //Sound
    public AudioSource audioSource;
    public AudioClip explosionClip;

    void Start()
    {
        countDown = delay;

        audioSource = GetComponent<AudioSource>();
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

        audioSource.PlayOneShot(explosionClip);
        gameObject.GetComponent<SphereCollider>().enabled=false;
        gameObject.GetComponent<MeshRenderer>().enabled=false;


        Destroy(gameObject,delay*2);
    }
}



















