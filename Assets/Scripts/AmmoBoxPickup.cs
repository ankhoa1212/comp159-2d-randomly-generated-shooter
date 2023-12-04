using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxPickup : MonoBehaviour
{
    public int ammoAmount = 10;
    public AmmoController.AmmoType ammoType; // Specify the ammo type in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AmmoController ammoController = other.GetComponent<AmmoController>();
            if (ammoController != null)
            {
                ammoController.IncreaseAmmo(ammoType, ammoAmount);
                Destroy(gameObject);
            }
        }
    }
}