using UnityEngine;

public class Weapon : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] protected WeaponData WeaponData;

    public int BulletRemaining { get; set; }

    public WeaponData Data => WeaponData;

    private void Awake()
    {
       _audioSource = gameObject.AddComponent<AudioSource>();
       _audioSource.playOnAwake = false;
       _audioSource.clip = WeaponData.FireSound;

       BulletRemaining = WeaponData.BulletsInMagazine;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        if (BulletRemaining <= 0)
        {
            return;
        }

        _audioSource?.Play();
        //Instantiate(WeaponData.FireParticle, _firePlace.position, Quaternion.identity);

        if (Physics.Raycast(origin, direction, out RaycastHit hit, 1000f))
        {
            Debug.Log("Hit");

            var hitPoint = hit.point;
            Instantiate(WeaponData.HitParticle, hitPoint, Quaternion.identity);

            BulletRemaining--;
            EventManager.OnWeaponShot.Invoke(BulletRemaining);
            WeaponData.CurrentBulletsInMagazine = BulletRemaining;

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

    public void Reload(int bulletCount)
    {
        BulletRemaining = bulletCount;
        WeaponData.CurrentBulletsInMagazine = BulletRemaining;
        EventManager.OnWeaponShot.Invoke(BulletRemaining);
    }
}
