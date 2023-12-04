using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private AmmoController ammoController;
    public WeaponType Weapon = WeaponType.Rifle;

    AudioSource _source;
    [SerializeField] private AudioClip rifleShot;

    void Start()
    {
        _source = this.GetComponent<AudioSource>();
        _source.clip = rifleShot;

        ammoController = GameObject.FindObjectOfType<AmmoController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammoController.DecreaseRifleAmmo()){
                Shoot();
                _source.Play();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
    }
}
