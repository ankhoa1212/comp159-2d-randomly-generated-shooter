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
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<MinimapIconController>().ResizeMinimapIcons();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        // if player has touched item, have item act accordingly
        switch (item)
        {
            case ItemType.Neighbor:
                FindObjectOfType<LevelController>().NeighborSaved();
                foreach (var roomController in FindObjectsOfType<RoomController>()) // check through all rooms
                {
                    roomController.RemoveItemFromList(gameObject); // remove item from item list if it exists
                }
                break;
            case ItemType.Gun:
                // TODO add new gun type to player
                break;
            case ItemType.Health:
                HealPlayer(other.gameObject);
                break;
            case ItemType.Door:
                GetComponent<DoorController>().OpenDoor();
                FindObjectOfType<LevelController>().NextLevel();
                break;
            case ItemType.RifleAmmoBox:
                IncreaseAmmo(Weapon.WeaponType.Rifle, 3);
                break;
            case ItemType.ShotgunAmmoBox:
                IncreaseAmmo(Weapon.WeaponType.Shotgun, 10);
                break;
            default:
                break;
        }
        Destroy(gameObject); // destroy item
    }

    private void IncreaseAmmo(Weapon.WeaponType type, int amount)
    {
        WeaponManager weaponManager = FindObjectOfType<WeaponManager>();
        Weapon weapon = FindObjectOfType<WeaponManager>().GetCurrentWeapon();
        // if current weapon doesn't match ammo type, add ammo to another weapon of correct type
        if (weapon.GetWeaponType() != type) 
        {
            weapon = weaponManager.GetWeaponOfType(type).GetComponent<Weapon>();
        }
        weapon.ChangeAmmo(amount);
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