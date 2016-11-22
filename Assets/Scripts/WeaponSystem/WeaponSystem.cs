using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSystem : MonoBehaviour 
{
    private Weapon[] weapons;
    public Weapon activeWeapon;

	void Start () 
    {
        GetWeapons();
	}

    public void GetWeapons()
    {
        weapons = GetComponentsInChildren<Weapon>();
        if (weapons.Length > 0)
        {
            activeWeapon = weapons[0];
            ActivateWeapons();
        }
    }

    public void ChooseWeapon(Weapon newWeapon)
    {
        activeWeapon = newWeapon;
        ActivateWeapons();
    }

    public void ChooseWeapon(string weaponName)
    {
        foreach (Weapon weapon in weapons)
        {
            if (weaponName == weapon.objName)
            {
                activeWeapon = weapon;
                ActivateWeapons();
                return;
            }
        }

        Debug.Log("Chosen weapon doesn't exist!");
    }

    private void ActivateWeapons()
    {
        foreach (Weapon weapon in weapons)
        {
            if (weapon == activeWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
        }
    }
}
