using UnityEngine;

public class Player : Essence
{
    [SerializeField] private Inventory _inventory;

    [SerializeField] private Weapon _weapon;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Start()
    {
        WeaponSwitcher.OnWeaponChanged.AddListener(SwitchWeapon);
    }

    public void SwitchWeapon(int weaponIndex)
    {

    }

    public void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _weapon.Shoot(ray.origin, ray.direction);
    }
}
