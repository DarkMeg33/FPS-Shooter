using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (_enemyCount == 0)
        {
            var winCount = PlayerPrefs.GetInt("WinCount");
            PlayerPrefs.SetInt("WinCount", ++winCount);

            SceneManager.LoadScene("Win Scene");
        }
    }
}
