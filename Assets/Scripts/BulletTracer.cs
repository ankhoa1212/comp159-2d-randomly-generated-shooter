using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

            // Apply damage to enemy
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        // Prevents Bullet game objects from destroying themselves when colliding with one another
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("ShotGunBullet"))
        {
            return;
        }
        
        // Destroys Bullet game object when colliding with any game object with a collider and is not tagged an "Enemy"
        Destroy(gameObject);
    }
}
