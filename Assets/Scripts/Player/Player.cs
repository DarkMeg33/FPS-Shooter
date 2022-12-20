using UnityEngine;

public class Player : Essence
{
    [SerializeField] private Inventory _inventory;

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

    public override void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Weapon.Shoot(ray.origin, ray.direction);
    }

    public override void Die()
    {
        if (gameObject.GetComponent<Player>() != null)
        {
            EventManager.OnPlayerDied.Invoke();
        }
    }
}
