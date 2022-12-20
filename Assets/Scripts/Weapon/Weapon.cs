using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireParticle;
    [SerializeField] private AudioSource _fireSound;
    [SerializeField] protected WeaponData WeaponData;

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        _fireParticle.Play();
        _fireSound.Play();

        if (Physics.Raycast(origin, direction, out RaycastHit hit, 1000f))
        {
            Debug.Log("Hit");
            Debug.DrawRay(origin, direction * 100f, Color.yellow, 3600f);

            IHitable enemy = hit.transform.gameObject.GetComponentInParent<IHitable>();

            if (enemy != null)
            {
                Debug.Log($"{nameof(enemy)}");
                enemy.ApplyDamage(WeaponData.Damage);

                if (enemy is Player)
                {
                    EventManager.OnPlayerDamaged.Invoke(WeaponData.Damage);
                }
            }
        }
    }
}
