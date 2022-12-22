using UnityEngine;
using UnityEngine.UI;

public class WeaponHUD : MonoBehaviour
{
    [SerializeField] private Image _weaponImage;
    [SerializeField] private TMPro.TextMeshProUGUI _weaponName;

    public void Awake()
    {
        EventManager.OnWeaponChanged.AddListener(ChangeHUD);
    }

    private void ChangeHUD(WeaponData weaponData)
    {
        _weaponImage.sprite = weaponData.Icon;
        _weaponName.text = weaponData.WeaponName;
    }
}
