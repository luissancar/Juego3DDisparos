using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public TextMeshProUGUI textAmmo;

    public Transform startPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AmmoBox"))
        {
            GameManager.instance.gunAmmo += other.gameObject
                .GetComponent<AmmoBox>().ammo;
            textAmmo.text = GameManager.instance.gunAmmo.ToString();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("SueloMuerte"))
        {
            GameManager.instance.LoseHealth(3);
            GetComponent<CharacterController>().enabled=false;
            gameObject.transform.position = startPosition.position;
            GetComponent<CharacterController>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemyBullet"))
        {
            GameManager.instance.LoseHealth(2);
        }
    }
}
