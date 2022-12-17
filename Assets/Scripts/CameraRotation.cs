using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _playerOrientation;

    private float _mouseSensitivity = 300f;

    private float _xCameraRotation = 0f;
    private float _yCameraRotation = 0f;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xCameraRotation -= mouseY;
        _xCameraRotation = Mathf.Clamp(_xCameraRotation, -90f, 90f);

        _yCameraRotation += mouseX;
        //_yCameraRotation = Mathf.Clamp(_yCameraRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xCameraRotation, _yCameraRotation, 0f);
        _playerOrientation.localRotation = Quaternion.Euler(0, _yCameraRotation, 0);
    }
}
