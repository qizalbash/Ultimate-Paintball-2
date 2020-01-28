using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public enum WeaponType
    {
        Auto,
        Semi
    }
    [Header("Weapon Settings")]
    public WeaponType Type;
    [Tooltip("Rounds per minute for normal weapons, bursts per minute for burst weapons.")]
    public float FireRate;
    public float Inaccuracy;

    [Header("Bullet Settings")]
    public float Speed;
    public float Radius;
    public int Count;

    [Header("Player Settings")]
    public float MoveSpeed;
    public float JumpHeight;
}
