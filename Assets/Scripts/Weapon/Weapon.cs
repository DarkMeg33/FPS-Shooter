using UnityEngine;

public class Weapon : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] protected WeaponData WeaponData;

    private void Awake()
    {
       _audioSource = gameObject.AddComponent<AudioSource>();
       _audioSource.playOnAwake = false;
       _audioSource.clip = WeaponData.FireSound;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        _audioSource?.Play();
        //Instantiate(WeaponData.FireParticle, _firePlace.position, Quaternion.identity);

        if (Physics.Raycast(origin, direction, out RaycastHit hit, 1000f))
        {
            Debug.Log("Hit");
            Debug.DrawRay(origin, direction * 100f, Color.yellow, 3600f);

            IHitable enemy = hit.transform.gameObject.GetComponentInParent<IHitable>();

            var hitPoint = hit.point;
            Instantiate(WeaponData.HitParticle, hitPoint, Quaternion.identity);

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
