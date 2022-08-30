using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GunData gunData;
    [SerializeField] Transform muzzle;
    [SerializeField] float bulletSpeed = 20;

    [Header("References")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    [SerializeField] AudioSource bulletSound;

    public void shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn);
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
        
        OnGunShoot();
    }

    private void OnGunShoot()
    {
        bulletSound.Play();
    }

}
