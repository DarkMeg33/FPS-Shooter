using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI healthText;
    private int _health = 100;

    public void Awake()
    {
        EventManager.OnPlayerDamaged.AddListener(ChangeHealth);
    }

    public void ChangeHealth(int damage)
    {
        _health -= damage;
        healthText.text = _health.ToString();
    }
}
