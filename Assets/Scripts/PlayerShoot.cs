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
    void CmdShoot(Vector3 _firePoint, Quaternion _fireRotation, float _bulletSpeed, float _bulletRadius, GameObject _owner)
    {
        GameObject _bullet = Instantiate(bulletPrefab, _firePoint, _fireRotation);
        NetworkServer.SpawnWithClientAuthority(_bullet, _owner);
        _bullet.GetComponent<Bullet>().RpcApplyBulletSettings(_bulletSpeed, _bulletRadius);
    }

    // Checks to see if the player is pressing the mouse button, what weapon type they are using, and what their cooldown is
    void AttemptShoot()
    {
        if (fireCooldown > 0f) { return; }

        Weapon _weapon = GetComponent<WeaponManager>().GetWeapon();

        if (_weapon.weaponType == Weapon.WeaponType.Semi)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(_weapon);
            }
        }
        else if (_weapon.weaponType == Weapon.WeaponType.Auto)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot(_weapon);
            }
        }
    }

    // Tells the server to fire the weapon
    void Shoot(Weapon _weapon)
    {
        CmdShoot(firePoint.position, firePoint.rotation, _weapon.bulletSpeed, _weapon.bulletRadius, gameObject);
        fireCooldown = Util.RPMToCooldown(_weapon.weaponRPM);
    }

    
}
