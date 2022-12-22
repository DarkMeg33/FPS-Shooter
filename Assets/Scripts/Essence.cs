using UnityEngine;

public abstract class Essence : MonoBehaviour, IHitable
{
    [SerializeField] private int _health = 100;
    [SerializeField] protected Weapon Weapon;

    [SerializeField] protected Transform WeaponHolder;

    public int Health => _health;

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        DieCallback();
    }

    public abstract void DieCallback();

    public abstract void Shoot();
}
