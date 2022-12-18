using UnityEngine;
using UnityEngine.Events;

public class WeaponSwitcher : MonoBehaviour
{
    public static UnityEvent<int> OnWeaponChanged { get; set; } = new UnityEvent<int>();

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Weapon switched");
        }
    }

    public void SwitchWeapon()
    {

    }
}
