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
    void CmdShoot(Vector3 _firePoint, Quaternion _fireRotation, float _bulletSpeedMax, float _bulletSpeedMin, float _bulletRadius, float _weaponInaccuracy, int _bulletCount, GameObject _owner)
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            float _hInaccuracy = Random.Range(-_weaponInaccuracy, _weaponInaccuracy);
            float _vInaccuracy = Random.Range(-_weaponInaccuracy, _weaponInaccuracy);
            _fireRotation = Quaternion.Euler(_fireRotation.eulerAngles + Vector3.up * _hInaccuracy + Vector3.right * _vInaccuracy);

            GameObject _bullet = Instantiate(bulletPrefab, _firePoint, _fireRotation);
            NetworkServer.SpawnWithClientAuthority(_bullet, _owner);
            float _bulletSpeed = Random.Range(_bulletSpeedMin, _bulletSpeedMax);
            _bullet.GetComponent<Bullet>().RpcApplyBulletSettings(_bulletSpeed, _bulletRadius);
        }
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
        CmdShoot(firePoint.position, firePoint.rotation, _weapon.bulletSpeedMax, _weapon.bulletSpeedMin, _weapon.bulletRadius, _weapon.weaponInaccuracy, _weapon.bulletCount, gameObject);
        fireCooldown = Util.RPMToCooldown(_weapon.weaponFireRate);
    }

    
}
