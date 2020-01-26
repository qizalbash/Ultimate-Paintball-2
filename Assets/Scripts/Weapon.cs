using UnityEngine;

[System.Serializable]
public class Weapon
{
    [Header("Weapon Settings")]
    public string Name;
    public enum WeaponType
    {
        Auto,
        Semi
    }
    public WeaponType Type;
    [Tooltip("Rounds per minute for normal weapons, bursts per minute for burst weapons.")]
    public float FireRate;
    public float Inaccuracy;

    [Header("Bullet Settings")]
    public float SpeedMax;
    public float SpeedMin;
    public float Radius;
    public int Count;

    [Header("Player Settings")]
    public float MoveSpeed;
    public float JumpHeight;
}
