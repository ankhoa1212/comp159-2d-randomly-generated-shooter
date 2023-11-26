using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    AudioSource _source;
    [SerializeField] private AudioClip rifleShot;

    void Start()
    {
        _source = this.GetComponent<AudioSource>();
        _source.clip = rifleShot;
    }
    
    // Update is called once per frame
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
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
    }
}
