using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent<int> OnPlayerDamaged = new UnityEvent<int>();
    public static UnityEvent OnPlayerDied = new UnityEvent();
    public static UnityEvent OnEnemyKilled = new UnityEvent();
    public static UnityEvent<GameObject> OnMessageDisplay = new UnityEvent<GameObject>();

    public static UnityEvent<WeaponData> OnWeaponChanged = new UnityEvent<WeaponData>();
}
