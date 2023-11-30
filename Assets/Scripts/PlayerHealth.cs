using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxPlayerHealth;
    [SerializeField] private Color flashColor;
    [SerializeField] private Color regularColor;
    [SerializeField] private float flashDuration;
    [SerializeField] private int numberOfFlashes;
    //[SerializeField] private Collider2D triggerCollider;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private AudioClip playerPain;
    [SerializeField] private AudioClip playerHealthIncrease;
    
    private AudioSource _audioSource;
    private int currentPlayerHealth;
    private bool isInvincible;
    // Start is called before the first frame update
    void Start()
    {
        isInvincible = false;
        currentPlayerHealth = maxPlayerHealth;
        _audioSource = GetComponent<AudioSource>();
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

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            StartCoroutine(Invincible());
            currentPlayerHealth -= damage;
            _audioSource.PlayOneShot(playerPain);
        }
    }
    
    public bool IsAlive()
    {
        if (currentPlayerHealth <= 0)
        {
            return false;
        }

        return true;
    }

    private IEnumerator Invincible()
    {
        int temp = 0;
        isInvincible = true;
        while (temp < numberOfFlashes)
        {
            playerSprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            playerSprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }

        isInvincible = false;
    }

    public int getPlayerHealth()
    {
        return currentPlayerHealth;
    }

    public int getMaxPlayerHealth()
    {
        return maxPlayerHealth;
    }

    public void IncreasePlayerHealth()
    {
        if (getPlayerHealth() < getMaxPlayerHealth())
        {
            currentPlayerHealth++;
            _audioSource.PlayOneShot(playerHealthIncrease);
        }

    }
}
