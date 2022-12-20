using UnityEngine;

public class DisplayMessageManager : MonoBehaviour
{
    private GameObject _message;
    public RectTransform DisplayMessageRect;

    private void Awake()
    {
        EventManager.OnMessageDisplay.AddListener(DisplayMessage);
    }

    private void DisplayMessage(GameObject messagePrefab)
    {
        Instantiate(messagePrefab, transform);
    }
}
