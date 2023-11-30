using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D healthPack)
    {
        if (_playerHealth.getPlayerHealth() <  _playerHealth.getMaxPlayerHealth())
        {
            _playerHealth.IncreasePlayerHealth();
        }
        Destroy(gameObject);
    }
}
