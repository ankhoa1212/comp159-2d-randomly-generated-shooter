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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
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
                    FindObjectOfType<AmmoController>().IncreaseAmmo(AmmoController.AmmoType.Rifle, 10); 
                    break;
                case ItemType.ShotgunAmmoBox:
                    FindObjectOfType<AmmoController>().IncreaseAmmo(AmmoController.AmmoType.Shotgun, 10); 
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        
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