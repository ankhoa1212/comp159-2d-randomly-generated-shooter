using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject rifle;
    public GameObject shotgun;

    public GameObject currentWeapon;

    void Start()
    {
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
        }
        else
        {
            Debug.LogWarning("Shotgun not assigned in the inspector!");
        }
    }
}
