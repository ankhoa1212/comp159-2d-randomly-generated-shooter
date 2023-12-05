using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    private int currentWeaponIndex;
    [SerializeField] private List<GameObject> possibleWeapons;
    [SerializeField] private List<GameObject> weapons;
    [SerializeField] private Image weaponBoxImage;
    private Weapon currentWeapon;
    private AmmoController ammoController;

    void Start()
    {
        // Set the initial weapon index
        currentWeaponIndex = 0;
        currentWeapon = weapons[0].GetComponent<Weapon>();
        // Display the initial ammo amount
        ammoController = FindObjectOfType<AmmoController>();
        ammoController.DisplayAmmo(currentWeapon.GetCurrentAmmo(), currentWeapon.GetMaximumAmmo());
    }

    void Update()
    {
        // switch weapon based on scroll wheel value
        SwitchWeapon(Input.GetAxis("Mouse ScrollWheel"));
        if (Input.GetButtonDown("Fire1"))
        {
            currentWeapon.FireWeapon();
        }
    }

    // switch weapon based on direction scrolled
    private void SwitchWeapon(float scrollValue)
    {
        if (scrollValue != 0f)
        {
            if (scrollValue > 0f)
            {
                currentWeaponIndex = Mathf.Clamp(currentWeaponIndex + 1, 0, weapons.Count - 1); // increase weapon index
            }
            else
            {
                currentWeaponIndex = Mathf.Clamp(currentWeaponIndex - 1, 0, weapons.Count - 1); // decrease weapon index
            }
        }
        ActivateWeapon(currentWeaponIndex);
    }

    // activate weapon and set weapon image based on index, deactivate all other weapons
    private void ActivateWeapon(int index)
    {
        for (var x = 0; x < weapons.Count; x++)
        {
            if (x == index)
            {
                weapons[x].SetActive(true);
                currentWeapon = weapons[x].GetComponent<Weapon>(); // set current weapon
                weaponBoxImage.sprite = currentWeapon.GetWeaponImage(); // set weapon box image sprite
                ammoController.DisplayAmmo(currentWeapon.GetCurrentAmmo(), currentWeapon.GetMaximumAmmo()); // show ammo
            }
            else
            {
                weapons[x].SetActive(false);
            }
        }
    }

    public GameObject GetCurrentWeapon()
    {
        return currentWeapon.gameObject;
    }
}
