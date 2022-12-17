using UnityEngine;

public class Essence : MonoBehaviour
{
    private int _health = 100;

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
