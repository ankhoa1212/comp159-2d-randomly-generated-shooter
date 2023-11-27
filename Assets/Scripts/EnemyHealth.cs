using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealth;
    //[SerializeField] private int damage;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAlive())
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
    }

    public bool IsAlive()
    {
        if (enemyHealth < 0)
        {
            return false;
        }

        return true;
    }
    
    
}
