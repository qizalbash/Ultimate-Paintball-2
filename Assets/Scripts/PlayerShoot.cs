using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Weapon weapon;

    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] Transform firePoint = null;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<BulletScript>().speed = weapon.bulletSpeed;
        bullet.GetComponent<SphereCollider>().radius = weapon.bulletRadius;
    }
}
