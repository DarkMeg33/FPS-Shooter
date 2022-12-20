using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    public string SceneName;

    private Button _button;

    public void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(LoadTargetScene);
    }

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void OnDestroy()
    {
        _button.onClick.RemoveListener(LoadTargetScene);
    }
}
