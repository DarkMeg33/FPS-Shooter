using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory", order = 51)]
public class Inventory : ScriptableObject
{
    [SerializeField] private List<WeaponData> _weapons;

    public List<WeaponData> Weapons => _weapons;
}
