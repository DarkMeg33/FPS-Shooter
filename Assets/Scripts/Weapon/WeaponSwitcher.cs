using UnityEngine;
using UnityEngine.Events;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
        }
    }

    public void SwitchWeapon(int weaponIndex)
    {
        EventManager.OnWeaponChanged.Invoke(GetWeaponFromInventory(weaponIndex));
    }

    public WeaponData GetWeaponFromInventory(int weaponIndex)
    {
        var weaponData = _inventory.Weapons[weaponIndex];

        return weaponData;
    }
}
