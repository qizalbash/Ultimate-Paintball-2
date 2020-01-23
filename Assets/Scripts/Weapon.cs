using UnityEngine;

[System.Serializable]
public class Weapon
{
    [Header("Weapon Settings")]
    public string weaponName;

    [Header("Bullet Settings")]
    public float bulletSpeed;
    public float bulletRadius;
}
