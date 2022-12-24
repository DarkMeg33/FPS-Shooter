using UnityEngine;
using UnityEngine.UI;

public class MovementStateHUD : MonoBehaviour
{
    private Image _movementImage;

    [SerializeField] private Sprite _walkingIcon;
    [SerializeField] private Sprite _sprintingIcon;

    private void Awake()
    {
        _movementImage = GetComponent<Image>();
        EventManager.OnMovementStateChanged.AddListener(ChangeHUD);
    }

    private void ChangeHUD(MovementState movementState)
    {
        _movementImage.sprite = movementState == MovementState.Walking ? _walkingIcon : _sprintingIcon;
    }
}
