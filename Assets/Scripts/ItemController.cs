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
        shotgunAmmoBox,
        Door
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        // if player has touched item, have item act accordingly
        switch (item)
        {
            case ItemType.Neighbor:
                FindObjectOfType<LevelController>().NeighborSaved();
                break;
            case ItemType.Gun:
                // TODO add new gun type to player
                break;
            case ItemType.Health:
                HealPlayer(other.gameObject);
                break;
            case ItemType.Door:
                
                FindObjectOfType<LevelController>().NextLevel();
                break;
            case ItemType.RifleAmmoBox:
                break;
            case ItemType.shotgunAmmoBox:
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }

    // Function heals player when colliding with health pack and player health is less player max health
    private void HealPlayer(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth.getPlayerHealth() < playerHealth.getMaxPlayerHealth())
        {
            playerHealth.IncreasePlayerHealth();
        }
    }
}
