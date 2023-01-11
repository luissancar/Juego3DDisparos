using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public TextMeshProUGUI textAmmo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AmmoBox"))
        {
            GameManager.instance.gunAmmo += other.gameObject
                .GetComponent<AmmoBox>().ammo;
            textAmmo.text = GameManager.instance.gunAmmo.ToString();
            Destroy(other.gameObject);
        }
    }
}
