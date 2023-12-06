using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoController : MonoBehaviour
{
    public TextMeshProUGUI ammoText;

    public void DisplayAmmo(int currentAmmo, int maximumAmmo)
    {
        ammoText.text = currentAmmo + "/" + maximumAmmo;
    }
}