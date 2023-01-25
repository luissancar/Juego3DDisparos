using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    public GameObject[] weapons;
    public int selectedWeapon = 0;


    

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            selectedWeapon = NextWeapon();
        }
        if (Input.GetAxis("Mouse ScrollWheel") <0)
        {
            selectedWeapon = PreviousWeapon();
        }
        WeaponNumeric();
        if (previousWeapon != selectedWeapon)
        {
            
            SelectWeapon();
        }

        
    }

    private void WeaponNumeric()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeapon = 2;
        }


    }

    private int PreviousWeapon()
    {
        if (selectedWeapon <=0)
        {
            return weapons.Length - 1;
        }
        else
        {
            return --selectedWeapon;
        }
    }

    private int NextWeapon()
    {
        if (selectedWeapon >= weapons.Length-1)
        {
            return 0;
        }
        else
        {
            return ++selectedWeapon;
        }
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            Debug.Log(weapon.ToString());
            if (weapon.CompareTag("weapon"))
            {
                Debug.Log("weapon");
                if (i == selectedWeapon)
                {
                    weapon.gameObject.SetActive(true);
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }
            }
            i++;
        }
    }
}
