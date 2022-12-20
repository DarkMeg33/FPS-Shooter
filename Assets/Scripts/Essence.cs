using UnityEngine;

public class Essence : MonoBehaviour, IHitable
{
    [SerializeField] private int _health = 100;
    [SerializeField] protected Weapon Weapon;

    public int Health => _health;

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void Shoot() {}
}
