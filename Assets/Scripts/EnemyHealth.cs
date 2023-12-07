using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

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
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine(destroyAfterSound());
        StartCoroutine(dropAmmo());
    }

    IEnumerator dropAmmo()
    {
        while (_sourceZombie.isPlaying)
        {
            yield return null;
        }
        GameObject ammoBoxPrefab = GetAmmoBoxPrefab();
        if (ammoBoxPrefab != null)
        {
            Instantiate(ammoBoxPrefab, transform.position, Quaternion.identity);
        }
    }
    
    IEnumerator destroyAfterSound()
    {
        while (_sourceZombie.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);
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

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        }
    }

    private GameObject GetAmmoBoxPrefab()
    {
        WeaponManager weaponManager = FindObjectOfType<WeaponManager>();
        return weaponManager.GetCurrentWeapon().GetAmmoBox();
    }
}
