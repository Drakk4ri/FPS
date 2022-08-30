using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GunData gunData;
    [SerializeField] Transform muzzle;
    [SerializeField] float bulletSpeed = 20;

    [Header("References")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;


    public void shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn);
        Debug.Log("shoot");

        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
            //velocity = transform.TransformDirection(Vector3(0, 0, bulletSpeed));

        OnGunShoot();

    }

    private void OnGunShoot()
    {
        // na póŸniej do wykonywania efektów po strzale
    }





    //private void Start()
    //{
    //    PlayerShoot.OnShootInput += Shoot;
    //}


    //public void Shoot()
    //{
    //    if (Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hitInfo, gunData.maxDistance))
    //    {
    //        Debug.Log("hit");
    //    }

    //    OnGunShoot();
    //}

    //private void OnGunShoot()
    //{
    //    // na póŸniej do wykonywania efektów po strzale
    //}





    //if (Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hitInfo, gunData.maxDistance))
    //{
    //    var bullet = Instantiate(bulletPrefab, bulletSpawn);
    //    Debug.Log("hit");
    //}
}
