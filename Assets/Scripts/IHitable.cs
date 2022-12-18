using UnityEngine;

public interface IHitable
{
    public int Health { get; }

    public void ApplyDamage(int damage);
    public void Die();
}
