using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private GameObject rifleAmmoBoxPrefab;
    [SerializeField] private GameObject shotgunAmmoBoxPrefab;

    public delegate void deadCallback();
    public deadCallback OnDead;

    [SerializeField] private int enemyHealth;
    [SerializeField] private int enemyDamage;
    private AudioSource _sourceZombie;

    [SerializeField] private AudioClip zombieInjured;
    [SerializeField] private AudioClip zombieDeath;

    // Start is called before the first frame update
    void Start()
    {
        _sourceZombie = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!IsAlive())
        {
            Die();
        }
        */
        
        if (enemyHealth <= 0)
        {
            Die();
        }
        
    }

    public void Die()
    {

        GameObject ammoBoxPrefab = GetAmmoBoxPrefab();
        if (ammoBoxPrefab != null)
        {
            Instantiate(ammoBoxPrefab, transform.position, Quaternion.identity);
        }
        // Destroy the enemy GameObject
        Destroy(gameObject);
        //OnDead();
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth > 0)
        {
            _sourceZombie.clip = zombieInjured;
            _sourceZombie.Play();
        }
        else
        {
            _sourceZombie.clip = zombieDeath;
            _sourceZombie.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        }
    }

    /*
    public bool IsAlive()
    {
        if (enemyHealth <= 0)
        {
            return false;
        }

        return true;
    }
    */
    private GameObject GetAmmoBoxPrefab()
    {

        WeaponSwitcher weaponSwitcher = FindObjectOfType<WeaponSwitcher>();

        if (weaponSwitcher != null)
        {
            if (weaponSwitcher.getCurrentWeapon().CompareTag("Rifle"))
            {
                return rifleAmmoBoxPrefab;
            }
            else if (weaponSwitcher.getCurrentWeapon().CompareTag("Shotgun"))
            {
                return shotgunAmmoBoxPrefab;
            }
        }
        return null; 
    }



    /*
    public bool IsAlive()
    {
        if (enemyHealth <= 0)
        {
            return false;
        }

        return true;
    }
    */
}
