using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject rifle;
    public GameObject shotgun;

    public GameObject currentWeapon;

    [SerializeField] private Image weaponBoxImage;
    [SerializeField] private Sprite rifleImg;
    [SerializeField] private Sprite shotgunImg;
    void Start()
    {
        //weaponBoxImage = currentWeapon.GetComponent<Image>();
        // Set the initial weapon
        SwitchToRifle();
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            SwitchToShotgun();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            SwitchToRifle();
        }
    }

    void SwitchToRifle()
    {
        if (shotgun != null)
        {
            shotgun.SetActive(false); // Deactivate the shotgun
        }

        if (rifle != null)
        {
            rifle.SetActive(true); // Activate the rifle
            currentWeapon = rifle;
            
            // Switches the weapon box image to the rifle
            if (weaponBoxImage != null)
            {
                weaponBoxImage.sprite = rifleImg;
            }

        }
        else
        {
            Debug.LogWarning("Rifle not assigned in the inspector!");
        }
    }

    void SwitchToShotgun()
    {
        if (rifle != null)
        {
            rifle.SetActive(false); // Deactivate the rifle
        }

        if (shotgun != null)
        {
            shotgun.SetActive(true); // Activate the shotgun
            currentWeapon = shotgun;
            
            // Switches the weapon box image to the shotgun
            if (weaponBoxImage != null)
            {
                weaponBoxImage.sprite = shotgunImg;
            }
        }
        else
        {
            Debug.LogWarning("Shotgun not assigned in the inspector!");
        }
    }
}
