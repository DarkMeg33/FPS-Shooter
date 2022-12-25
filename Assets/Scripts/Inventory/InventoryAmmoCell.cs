using UnityEngine;

[CreateAssetMenu(menuName = "InventoryAmmoCell", order = 51)]
public class InventoryAmmoCell : ScriptableObject
{
    public int AmmoCount;
    public string AmmoType;
}