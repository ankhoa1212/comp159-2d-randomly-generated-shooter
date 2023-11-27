using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
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

    public void Damage(int damage)
    {
        playerHealth -= damage;
    }
    
    public bool IsAlive()
    {
        if (playerHealth < 0)
        {
            return false;
        }

        return true;
    }
}
