using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{

    // Weapon handler which allows the player to select which weapon is equipped by pressing 1-4 on keyboard
    // (subject to change if more/less weapons later on)

    //Index of currently selected weapon
    // (starts with 0 at child 1, and goes on)
    public int selectedWeapon = 0;
    void Start()
    {
        selectWeapon();
    }

    
    void Update()
    {
        //Changes selected weapon based on input, if the weapon changes, then call the function
        int previousWeapon = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }
         else if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
        {
            selectedWeapon = 4;
        }

        //Checks if the index of the selected weapon changed during this instance of update
        //If so, call the function to change it 
        if (selectedWeapon != previousWeapon)
            selectWeapon();
    }

    //Iterates through each child transform of the current object (which is the weapon handler)
    //If the child's index matches the index of selected weapon, then it sets it to true, else it disables it
    void selectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
