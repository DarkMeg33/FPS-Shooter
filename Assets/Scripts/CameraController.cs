using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _mouseSensitivity = 300f;

    private float _xRotationCamera = 0f;
    private float _yRotationCamera = 0f;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotationCamera -= mouseY;
        _xRotationCamera = Mathf.Clamp(_xRotationCamera, -90f, 90f);

        _yRotationCamera -= mouseX;
        //_yRotationCamera = Mathf.Clamp(_yRotationCamera, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotationCamera, -_yRotationCamera, 0f);
    }
}
