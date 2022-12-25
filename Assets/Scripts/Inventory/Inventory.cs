using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory", order = 51)]
public class Inventory : ScriptableObject
{
    [SerializeField] private List<WeaponData> _weapons;

    [SerializeField] private List<InventoryAmmoCell> _ammo;

    public List<WeaponData> Weapons => _weapons;

    public List<InventoryAmmoCell> Ammo => _ammo;
}


