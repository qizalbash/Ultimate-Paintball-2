using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(WeaponManager))]
public class PlayerShoot : NetworkBehaviour
{
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] Transform firePoint = null;

    float fireCooldown = 0f;

    private void Update()
    {
        if (fireCooldown > 0f) { fireCooldown -= Time.deltaTime; }
        AttemptShoot();
    }

    // Fires the weapon and tells the server
    // LocalPlayers gets player authority
    [Command]
    void CmdShoot(Vector3 firePoint, Quaternion fireRotation, float bulletSpeed, float bulletRadius, float weaponInaccuracy, int bulletCount)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float hInaccuracy = Random.Range(-weaponInaccuracy, weaponInaccuracy);
            float vInaccuracy = Random.Range(-weaponInaccuracy, weaponInaccuracy);
            fireRotation = Quaternion.Euler(fireRotation.eulerAngles + (Vector3.up * hInaccuracy) + (Vector3.right * vInaccuracy));

            GameObject bullet = Instantiate(bulletPrefab, firePoint, fireRotation);
            NetworkServer.SpawnWithClientAuthority(bullet, connectionToClient);
            bullet.GetComponent<Bullet>().RpcApplyBulletSettings(bulletSpeed, bulletRadius);
        }
    }

    // Checks to see if the player is pressing the mouse button, what weapon type they are using, and what their cooldown is
    void AttemptShoot()
    {
        if (fireCooldown > 0f)
            return;

        Weapon weapon = GetComponent<WeaponManager>().GetWeapon();

        if (weapon.Type == Weapon.WeaponType.Semi && Input.GetButtonDown("Fire1") || weapon.Type == Weapon.WeaponType.Auto && Input.GetButton("Fire1"))
            Shoot(weapon);
    }

    // Tells the server to fire the weapon
    void Shoot(Weapon weapon)
    {
<<<<<<< HEAD
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<BulletScript>().speed = weapon.bulletSpeed;
        bullet.GetComponent<SphereCollider>().radius = weapon.bulletRadius;
=======
        CmdShoot(firePoint.position, firePoint.rotation, weapon.Speed, weapon.Radius, weapon.Inaccuracy, weapon.Count);
        fireCooldown = Util.RPMToCooldown(weapon.FireRate);
>>>>>>> ffd5269ea965ed0e1d4f41a6ecf392b0942575cd
    }
}
