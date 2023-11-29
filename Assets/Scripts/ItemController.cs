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
        Health
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
                // TODO maybe add points?
                break;
            case ItemType.Gun:
                // TODO add new gun type to player
                break;
            case ItemType.Health:
                // TODO add health to player
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }
}
