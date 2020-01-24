using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Weapon weapon;

    public Weapon GetWeapon()
    {
        return weapon;
    }

    public void EquipWeapon(Weapon _weapon)
    {
        weapon = _weapon;

        // Here is where you can set weapon graphics in the future
    }
}
