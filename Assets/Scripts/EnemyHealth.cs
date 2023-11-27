using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealth;
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
