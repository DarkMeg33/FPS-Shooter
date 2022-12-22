using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapon Data", order = 51)]
public class WeaponData : ScriptableObject
{
    [SerializeField] private string _weaponName;
    [SerializeField] private Sprite _icon;

    [SerializeField] private int _damage;
    
    [SerializeField] private ParticleSystem _fireParticle;
    [SerializeField] private AudioClip _fireSound;
    [SerializeField] private GameObject _weaponPrefab;

    public string WeaponName => _weaponName;
    public Sprite Icon => _icon;
    public int Damage => _damage;
    public AudioClip FireSound => _fireSound;
    public ParticleSystem FireParticle => _fireParticle;
    public GameObject WeaponPrefab => _weaponPrefab;
}
