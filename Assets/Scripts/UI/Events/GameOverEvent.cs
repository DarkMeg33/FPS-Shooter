using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverEvent : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPrefab;

    public void Awake()
    {
        EventManager.OnPlayerDied.AddListener(IncreaseLoseCount);
    }

    private void IncreaseLoseCount()
    {
        var loseCount = PlayerPrefs.GetInt("LoseCount");
        PlayerPrefs.SetInt("LoseCount", ++loseCount);

        SceneManager.LoadScene("Lose Scene");
        //EventManager.OnMessageDisplay.Invoke(_gameOverPrefab);
    }
}
