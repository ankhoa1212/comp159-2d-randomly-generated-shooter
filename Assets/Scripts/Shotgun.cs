using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public int numberOfBullets = 3;

    AudioSource _source;
    [SerializeField] private AudioClip shotgunShot;
    
    void Start()
    {
        _source = this.GetComponent<AudioSource>();
        _source.clip = shotgunShot;
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            _source.Play();
        }
    }

    void Shoot()
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            Quaternion bulletRotation = shootingPoint.rotation * Quaternion.Euler(0, 0, Random.Range(-10f, 10f));
            Instantiate(bulletPrefab, shootingPoint.position, bulletRotation);
        }
    }
}
