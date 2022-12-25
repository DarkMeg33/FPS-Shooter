using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCombatController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _combatVirtualCamera;
    [SerializeField] private float _normalSensitivity;
    [SerializeField] private float _aimSensitivity;
    [SerializeField] private LayerMask _aimMask = new LayerMask();

    private ThirdPersonController _thirdPersonController;
    private StarterAssetsInputs _inputs;
    private Animator _animator;

    private void Awake()
    {
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _inputs = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_inputs.aim)
        {
            var mouseWorldPosition = Vector3.zero;

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _aimMask))
            {
                mouseWorldPosition = hit.point;
            }

            if (!_combatVirtualCamera.gameObject.activeInHierarchy)
            {
                _combatVirtualCamera.gameObject.SetActive(true);
                _thirdPersonController.SetSensitivity(_aimSensitivity);
                _thirdPersonController.SetRotateOnMove(false);

                EventManager.OnCameraStyleChanged.Invoke(ThirdPersonCam.CameraStyle.Combat);
            }

            var worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;

            var aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            if (_combatVirtualCamera.gameObject.activeInHierarchy)
            {
                _combatVirtualCamera.gameObject.SetActive(false);
                _thirdPersonController.SetSensitivity(_normalSensitivity);
                _thirdPersonController.SetRotateOnMove(true);

                EventManager.OnCameraStyleChanged.Invoke(ThirdPersonCam.CameraStyle.Basic);
            }
        }
    }
}
