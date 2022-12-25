using UnityEngine;
using UnityEngine.UI;

public class WeaponHUD : MonoBehaviour
{
    [SerializeField] private Image _weaponImage;
    [SerializeField] private TMPro.TextMeshProUGUI _weaponName;

    [SerializeField] private Image _bulletImage;
    [SerializeField] private TMPro.TextMeshProUGUI _bulletCountText;
    [SerializeField] private TMPro.TextMeshProUGUI _bulletTotalCountText;
    
    public void Awake()
    {
        EventManager.OnWeaponChanged.AddListener(ChangeHUD);
        EventManager.OnWeaponShot.AddListener(ChangeBulletCountHUD);
        EventManager.OnWeaponReloaded.AddListener(ChangeTotalBullerCountHUD);
    }

    private void ChangeTotalBullerCountHUD(int totalBullets)
    {
        _bulletTotalCountText.text = totalBullets.ToString();
    }

    private void ChangeBulletCountHUD(int bulletsRemaining)
    {
        _bulletCountText.text = $"{bulletsRemaining}/";
    }

    private void ChangeHUD(WeaponData weaponData)
    {
        _weaponImage.sprite = weaponData.Icon;
        _weaponName.text = weaponData.WeaponName;

        ChangeBulletCountHUD(weaponData.CurrentBulletsInMagazine);
        ChangeTotalBullerCountHUD(weaponData.AmmoType.AmmoCount);
    }
}
