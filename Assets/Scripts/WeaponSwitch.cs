using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    private int currentWeaponIndex;
    [SerializeField] private List<GameObject> weapons;
    [SerializeField] private List<Sprite> weaponImage;
    [SerializeField] private Image weaponBoxImage;
    private GameObject currentWeapon;
    void Start()
    {
        // Set the initial weapon index
        currentWeaponIndex = 0;
    }

    void Update()
    {
        // switch weapon based on scroll wheel value
        SwitchWeapon(Input.GetAxis("Mouse ScrollWheel"));
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
                weaponBoxImage.sprite = weaponImage[x]; // set weapon box image sprite
                currentWeapon = weapons[x];
            }
            else
            {
                weapons[x].SetActive(false);
            }
        }
    }

    public GameObject getCurrentWeapon()
    {
        return currentWeapon;
    }
}
