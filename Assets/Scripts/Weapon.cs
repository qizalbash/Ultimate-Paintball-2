using UnityEngine;

[System.Serializable]
public class Weapon
{
    [Header("Weapon Settings")]
    public string weaponName;
    public enum WeaponType {Semi, Auto};
    public WeaponType weaponType;
    [Tooltip("Rounds per minute for normal weapons, bursts per minute for burst weapons.")]
    public float weaponFireRate;
    public float weaponInaccuracy;

    [Header("Bullet Settings")]
    public float bulletSpeedMax;
    public float bulletSpeedMin;
    public float bulletRadius;
    public int bulletCount;

    [Header("Player Settings")]
    public float playerMoveSpeed;
    public float playerJumpHeight;
}
