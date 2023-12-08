using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip landmineBeeps;
    [SerializeField] private AudioClip explosion;

    [SerializeField] private int damage = 2;

    [SerializeField] private GameObject explosionPrefab;

    private bool isBeeping;
    
    // This adjusts the size of the radius of any game object that will receive damage once a landmine is triggered 
    public float damageRadius;
    
    private GameObject playerObject;
    private GameObject[] enemyObjects;
    
    private PlayerHealth _playerHealth;
    private EnemyHealth _enemyHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        isBeeping = false;
        //damageRadius.SetActive(false);
        
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
            // Play the landmine beeping audio before explosion audio
            isBeeping = true;
            _audioSource.PlayOneShot(landmineBeeps);
            StartCoroutine(waitForBeeps(other));

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

        Vector2 landminePosition = gameObject.transform.position;
        // Calls for the landmine's damage function
        DealDamageInRadius();
        
        // Wait until the game objects within the damage radius are damaged and then destroy the landmine
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
        GameObject explosionObject = Instantiate(explosionPrefab, landminePosition, Quaternion.identity);
        Animator explodeAnimator = explosionObject.GetComponent<Animator>();
        float explosionDuration = explodeAnimator.runtimeAnimatorController.animationClips[0].length;
        Destroy(explosionObject, explosionDuration);
    }
    
    // Function deals damage to all the Player and Enemy game objects if they're within the landmine's damage radius
    void DealDamageInRadius()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, damageRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player") && (collider.TryGetComponent(out _playerHealth)))
            {
                _playerHealth.TakeDamage(damage);
            }

            if (collider.CompareTag("Enemy") && (collider.TryGetComponent(out _enemyHealth)))
            {
                _enemyHealth.TakeDamage(damage);
            }
        }
    }
    
    // Draws a circle in the scene view to see the damage radius
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, this.damageRadius);
    }
}
