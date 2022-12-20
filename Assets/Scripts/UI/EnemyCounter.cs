using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI EnemyText;

    private int _enemyCount;

    public void Awake()
    {
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        EnemyText.text = $"Enemy count: {_enemyCount}";
        EventManager.OnEnemyKilled.AddListener(DecreaseEnemyCount);
    }

    public void DecreaseEnemyCount()
    {
        _enemyCount--;
        EnemyText.text = $"Enemy count: {_enemyCount}";
    }
}
