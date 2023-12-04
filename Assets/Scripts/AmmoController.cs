using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoController : MonoBehaviour
{
    public int maxRifleAmmo = 30;
    private int currentRifleAmmo;

    public int maxShotgunAmmo = 18;
    private int currentShotgunAmmo;

    public TextMeshProUGUI ammoText;

    void Start()
    {
        currentRifleAmmo = maxRifleAmmo;
        currentShotgunAmmo = maxShotgunAmmo;
        ShowRifleAmmo(); // Initial display
        ShowShotgunAmmo(); // Initial display
    }

    public bool DecreaseRifleAmmo()
    {
        if (currentRifleAmmo > 0)
        {
            currentRifleAmmo--;
            ShowRifleAmmo();
            
            return true;
        }
        return false;
    }

    public bool DecreaseShotgunAmmo()
    {
        if (currentShotgunAmmo > 0)
        {
            currentShotgunAmmo--;
            ShowShotgunAmmo();
            
            return true;
        }
        return false;
    }

    public void IncreaseAmmo(AmmoType ammoType, int amount)
    {
        switch (ammoType)
        {
            case AmmoType.Rifle:
                currentRifleAmmo = Mathf.Min(currentRifleAmmo + amount, maxRifleAmmo);
                ShowRifleAmmo();
                break;
            case AmmoType.Shotgun:
                currentShotgunAmmo = Mathf.Min(currentShotgunAmmo + amount, maxShotgunAmmo);
                ShowShotgunAmmo();
                break;
        }
    }

    public void ShowRifleAmmo()
    {
        if (ammoText != null)
        {
            ammoText.text = currentRifleAmmo + "/30";
        }
    }

    public void ShowShotgunAmmo()
    {
        if (ammoText != null)
        {
            ammoText.text = currentShotgunAmmo + "/18";
        }
    }

    public enum AmmoType
    {
        Rifle,
        Shotgun,
    }
}