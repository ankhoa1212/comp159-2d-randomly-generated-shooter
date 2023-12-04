using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private ItemType item;

    private enum ItemType
    {
        Neighbor,
        Gun,
        Health,
        RifleAmmoBox,
        ShotgunAmmoBox,
        Door
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        AmmoController ammoController = other.GetComponent<AmmoController>();
        if (ammoController != null)
        {
            switch (item)
            {
                case ItemType.Neighbor:
                    FindObjectOfType<LevelController>().NeighborSaved();
                    break;
                case ItemType.Gun:
                    // TODO: Add new gun type to player
                    break;
                case ItemType.Health:
                    HealPlayer(other.gameObject);
                    break;
                case ItemType.Door:
                    FindObjectOfType<LevelController>().NextLevel();
                    break;
                case ItemType.RifleAmmoBox:
                    ammoController.IncreaseAmmo(AmmoController.AmmoType.Rifle, 10); // Adjust the amount as needed
                    break;
                case ItemType.ShotgunAmmoBox:
                    ammoController.IncreaseAmmo(AmmoController.AmmoType.Shotgun, 10); // Adjust the amount as needed
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }

    void HealPlayer(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null && playerHealth.getPlayerHealth() < playerHealth.getMaxPlayerHealth())
        {
            playerHealth.IncreasePlayerHealth();
        }
    }
}