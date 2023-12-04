using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject ShotgunPrefab;
    public int numberOfBullets = 3;

    AudioSource _source;
    [SerializeField] private AudioClip shotgunShot;
    private AmmoController ammoController;
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = shotgunShot;
        ammoController = FindObjectOfType<AmmoController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
            _source.Play();

            // Update ammo count after shooting
            if (ammoController != null)
            {
                ammoController.DecreaseShotgunAmmo();
            }
        }
    }

    void Shoot()
    {
        for (int i = 0; i < 5; i++) 
        {
            Instantiate(ShotgunPrefab, shootingPoint.position, shootingPoint.rotation * Quaternion.Euler(0, 0, Random.Range(-10f, 10f)));
        }
    }
}

