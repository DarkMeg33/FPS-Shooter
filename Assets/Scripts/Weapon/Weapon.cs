using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected int Damage { get; set; } = 20;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        Debug.Log("Shoot");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
        {
            Debug.Log("Hit");
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.yellow, 3600f);
            
            Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                Debug.Log($"{nameof(enemy)}");
                enemy.ApplyDamage(Damage);
            }
        }
    }
}
