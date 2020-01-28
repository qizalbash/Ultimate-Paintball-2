using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Weapon weapon;

    public Weapon GetWeapon() => weapon;

    public void EquipWeapon(Weapon weapon)
    {
        this.weapon = weapon;

        // TODO: set weapon graphics
    }
}
