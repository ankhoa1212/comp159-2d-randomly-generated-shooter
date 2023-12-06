using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip landmineBeeps;
    [SerializeField] private AudioClip explosion;

    [SerializeField] private GameObject damageRadius;
    [SerializeField] private int damage = 2;

    private bool isBeeping;
    
    private List<Collider2D> collidersInRadius = new List<Collider2D>();
    
    private GameObject playerObject;
    private GameObject[] enemyObjects;
    
    private PlayerHealth _playerHealth;
    private EnemyHealth _enemyHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        isBeeping = false;
        damageRadius.SetActive(false);
        
        // Grabbing player game object for the PlayerHealth script
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            _playerHealth = playerObject.GetComponent<PlayerHealth>();
        }
        
        // Grabbing all enemy game objects for their EnemyHealth script
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemyObject in enemyObjects)
        {
            _enemyHealth = enemyObject.GetComponent<EnemyHealth>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only player and enemy game objects trigger landmine audio
        if (!isBeeping && (other.CompareTag("Player") || other.CompareTag("Enemy")))
        {
            damageRadius.SetActive(true);
            collidersInRadius.Add(other);
            // Play the landmine beeping audio before explosion audio
            isBeeping = true;
            _audioSource.PlayOneShot(landmineBeeps);
            StartCoroutine(waitForBeeps(other));
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        // Remove collider from the list when it exits the damage radius
        if (collidersInRadius.Contains(other))
        {
            collidersInRadius.Remove(other);
        }
    }
    
    // Function plays the explosion AFTER the beeping audio concludes
    IEnumerator waitForBeeps(Collider2D other)
    {
        while (_audioSource.isPlaying)
        {
            yield return null;
        }

        if (_audioSource != null)
        {
            _audioSource.PlayOneShot(explosion);
        }
        
        // Calls for the landmine's damage function
        DealDamageInRadius();
        
        // Wait until the game objects within the damage radius are damaged and then destroy the landmine
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
    
    // Function deals damage to all the Player and Enemy game objects if they're within the landmine's damage radius
    void DealDamageInRadius()
    {
        foreach (Collider2D collider in collidersInRadius)
        {
            if (collider.CompareTag("Player") && _playerHealth != null)
            {
                _playerHealth.TakeDamage(damage);
                //Debug.Log("PLAYER TOOK " + damage + " DAMAGE!!!");
            }

            if (collider.CompareTag("Enemy") && _enemyHealth != null)
            {
                _enemyHealth.TakeDamage(damage);
                //Debug.Log("ENEMY TOOK " + damage + " DAMAGE!!!");
            }
        }
    }
}
