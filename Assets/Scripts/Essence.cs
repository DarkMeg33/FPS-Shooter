using UnityEngine;

public abstract class Essence : MonoBehaviour, IHitable
{
    [SerializeField] private int _health = 100;
    [SerializeField] protected Weapon Weapon;

    [SerializeField] protected Transform WeaponHolder;

    protected Animator _animator;

    public int Health => _health;

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        ApplyDamageCallback();

        if (_health <= 0)
        {
            Die();
        }
    }

    public abstract void ApplyDamageCallback();

    public virtual void Die()
    {
        Destroy(gameObject);
        DieCallback();
    }

    public abstract void DieCallback();

    public abstract void Shoot();
}
