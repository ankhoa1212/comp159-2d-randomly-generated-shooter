using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    private int currentWeaponIndex;
    [SerializeField] private List<GameObject> playerWeapons; // player's current weapons
    [SerializeField] private Image weaponBoxImage;
    private Weapon currentWeapon;
    private DisplayController display;

    void Start()
    {
        // Set the initial weapon index
        currentWeaponIndex = 0;
        currentWeapon = playerWeapons[0].GetComponent<Weapon>();
        // Display the initial ammo amount
        display = GetComponent<DisplayController>();
        DisplayAmmo();
    }

    void Update()
    {
        // switch weapon based on scroll wheel value
        SwitchWeapon(Input.GetAxis("Mouse ScrollWheel"));
        if (Input.GetButtonDown("Fire1"))
        {
            currentWeapon.FireWeapon();
            DisplayAmmo();
        }
    }

    private void DisplayAmmo()
    {
        display.SetText($"{currentWeapon.GetCurrentAmmo()}/{currentWeapon.GetMaximumAmmo()}");
    }

    // switch weapon based on direction scrolled
    private void SwitchWeapon(float scrollValue)
    {
        if (scrollValue != 0f)
        {
            if (scrollValue > 0f)
            {
                currentWeaponIndex = Mathf.Clamp(currentWeaponIndex + 1, 0, playerWeapons.Count - 1); // increase weapon index
            }
            else
            {
                currentWeaponIndex = Mathf.Clamp(currentWeaponIndex - 1, 0, playerWeapons.Count - 1); // decrease weapon index
            }
        }
        ActivateWeapon(currentWeaponIndex);
    }

    // activate weapon and set weapon image based on index, deactivate all other weapons
    private void ActivateWeapon(int index)
    {
        for (var x = 0; x < playerWeapons.Count; x++)
        {
            if (x == index)
            {
                currentWeapon = playerWeapons[x].GetComponent<Weapon>(); // set current weapon
                weaponBoxImage.sprite = currentWeapon.GetWeaponImage(); // set weapon box image sprite
                DisplayAmmo();
                break;
            }
        }
    }

    public Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    // return a player's weapon that has the corresponding type
    public GameObject GetWeaponOfType(Weapon.WeaponType type)
    {
        foreach (var weapon in playerWeapons)
        {
            if (weapon.GetComponent<Weapon>().GetWeaponType() == type)
            {
                return weapon;
            }
        }
        return null; // player does not have a weapon with the corresponding type
    }

    // add new weapon to the player's inventory
    public void AddWeapon(GameObject newWeapon)
    {
        if (!playerWeapons.Contains(newWeapon))
        {
            playerWeapons.Add(newWeapon);
        }
    }
}
