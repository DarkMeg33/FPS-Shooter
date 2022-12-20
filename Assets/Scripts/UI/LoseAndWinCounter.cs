using UnityEngine;
using UnityEngine.UI;

public class LoseAndWinCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI LoseCountText;
    public TMPro.TextMeshProUGUI WinCountText;

    public void Awake()
    {
        //Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;

        LoseCountText.text = $"Lose Count: {PlayerPrefs.GetInt("LoseCount")}";
        WinCountText.text = $"Win Count: {PlayerPrefs.GetInt("WinCount")}";
    }

    //public void OnDestroy()
    //{
    //    Time.timeScale = 1;
    //}
}
