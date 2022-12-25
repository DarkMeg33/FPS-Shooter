using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Essence
{
    [SerializeField] private Inventory _inventory;

    private StarterAssetsInputs _inputs;

    public void Awake()
    {
        EventManager.OnWeaponChanged.AddListener(SwitchWeapon);
        _inputs = GetComponent<StarterAssetsInputs>();
    }

    public void Update()
    {
        if (_inputs.shoot)
        {
            if (_inputs.aim)
            {
                Shoot();
            }

            _inputs.shoot = false;
        }
    }

    public void SwitchWeapon(WeaponData weaponData)
    {
        Destroy(Weapon.gameObject);
        Weapon = Instantiate(weaponData.WeaponPrefab, WeaponHolder).GetComponent<Weapon>();
    }

    public override void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Weapon.Shoot(ray.origin, ray.direction);
    }

    public override void ApplyDamageCallback()
    {
        
    }

    public override void DieCallback()
    {
        if (gameObject.GetComponent<Player>() != null)
        {
            EventManager.OnPlayerDied.Invoke();
        }
    }
}
