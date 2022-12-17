using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;

    public void Update()
    {
        transform.position = _cameraPosition.position;
    }
}
