using System.Linq;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Essence
{
    [SerializeField] private Inventory _inventory;

    private StarterAssetsInputs _inputs;

    private int _animIdShot;
    private int _animIdReload;

    public void Awake()
    {
        EventManager.OnWeaponChanged.AddListener(SwitchWeapon);
        _inputs = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
        SetAnimIDs();
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

        if (_inputs.reload)
        {
            Reload();
        }
    }

    public void SetAnimIDs()
    {
        _animIdReload = Animator.StringToHash("Reload");
        _animIdShot = Animator.StringToHash("Shot");
    }

    public void SwitchWeapon(WeaponData weaponData)
    {
        Destroy(Weapon.gameObject);
        Weapon = Instantiate(weaponData.WeaponPrefab, WeaponHolder).GetComponent<Weapon>();
    }

    public override void Shoot()
    {
        _animator.SetTrigger(_animIdShot);
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Weapon.Shoot(ray.origin, ray.direction);
    }

    public void Reload()
    {
        _animator.SetTrigger(_animIdReload);

        int bulletsForWeapon = 0;
        var bulletsNeed = Weapon.Data.BulletsInMagazine - Weapon.Data.CurrentBulletsInMagazine;

        if (bulletsNeed > Weapon.Data.AmmoType.AmmoCount)
        {
            bulletsForWeapon = Weapon.Data.AmmoType.AmmoCount + Weapon.Data.CurrentBulletsInMagazine;
            Weapon.Data.AmmoType.AmmoCount = 0;
        }
        else if (bulletsNeed < Weapon.Data.AmmoType.AmmoCount)
        {
            bulletsForWeapon = Weapon.Data.CurrentBulletsInMagazine + bulletsNeed;
            Weapon.Data.AmmoType.AmmoCount -= bulletsNeed;
        }

        EventManager.OnWeaponReloaded.Invoke(Weapon.Data.AmmoType.AmmoCount);
        Weapon.Reload(bulletsForWeapon);
        _inputs.reload = false;
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
