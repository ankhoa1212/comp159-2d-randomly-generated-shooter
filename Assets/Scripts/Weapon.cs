using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponType weapon;
    public enum WeaponType
    {
        Rifle,
        Shotgun
    }

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Sprite weaponImage;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject ammoBoxPrefab;
    [SerializeField] private int maximumAmmo;
    [SerializeField] private int bulletsPerShot;
    [SerializeField] private float bulletSpread = 0f;
    [SerializeField] private AudioClip shotSound;
    private int currentAmmo;
    private AudioSource source;

    void Start()
    {
        currentAmmo = maximumAmmo;
        Debug.Log(currentAmmo);
        source = GetComponent<AudioSource>();
        source.clip = shotSound;
    }

    public Sprite GetWeaponImage()
    {
        return weaponImage;
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }
    
    public int GetMaximumAmmo()
    {
        return maximumAmmo;
    }

    public GameObject GetAmmoBox()
    {
        return ammoBoxPrefab;
    }
    
    public void FireWeapon()
    {
        if (currentAmmo > 0)
        {
            for (var x = 0; x < bulletsPerShot; x++)
            {
                if (currentAmmo > 0)
                {
                    ChangeAmmo(-1);
                    ShootBullet();
                }
            }
            source.Play();
        }
    }

    public void ChangeAmmo(int ammo)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + ammo, 0, maximumAmmo);
    }

    public WeaponType GetWeaponType()
    {
        return weapon;
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation * Quaternion.Euler(0, 0, Random.Range(-bulletSpread, bulletSpread)));
    }

}
