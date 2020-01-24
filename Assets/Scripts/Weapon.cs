using UnityEngine;

[System.Serializable]
public class Weapon
{
    [Header("Weapon Settings")]
    public string weaponName;
    public enum WeaponType {Semi, Auto};
    public WeaponType weaponType;
    public float weaponRPM;

    [Header("Bullet Settings")]
    public float bulletSpeed;
    public float bulletRadius;

    [Header("Player Settings")]
    public float playerMoveSpeed;
    public float playerJumpHeight;
}
