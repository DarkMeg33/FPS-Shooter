using UnityEngine;

public class Player : Essence
{
    [SerializeField] private Inventory _inventory;

    public void Awake()
    {
        EventManager.OnWeaponChanged.AddListener(SwitchWeapon);
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void SwitchWeapon(Weapon weapon)
    {
        Destroy(Weapon.gameObject);
        Weapon = Instantiate(weapon.gameObject, WeaponHolder).GetComponent<Weapon>();
    }

    public override void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Weapon.Shoot(ray.origin, ray.direction);
    }

    public override void DieCallback()
    {
        if (gameObject.GetComponent<Player>() != null)
        {
            EventManager.OnPlayerDied.Invoke();
        }
    }
}
