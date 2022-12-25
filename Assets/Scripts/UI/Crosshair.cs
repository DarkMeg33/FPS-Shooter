using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Image _crossHair;

    private void Awake()
    {
        _crossHair = GetComponent<Image>();
        _crossHair.gameObject.SetActive(false);
        EventManager.OnCameraStyleChanged.AddListener(ChangeHUD);
    }

    private void ChangeHUD(ThirdPersonCam.CameraStyle cameraStyle)
    {
        if (cameraStyle == ThirdPersonCam.CameraStyle.Basic)
        {
            _crossHair.gameObject.SetActive(false);
        }

        if (cameraStyle == ThirdPersonCam.CameraStyle.Combat)
        {
            _crossHair.gameObject.SetActive(true);
        }
    }

    //private void Update()
    //{
    //    if (ThirdPersonCam.CamStyle == ThirdPersonCam.CameraStyle.Basic)
    //    {
    //        if (_crossHair.gameObject.activeInHierarchy)
    //        {
    //            _crossHair.gameObject.SetActive(false);
    //        }
    //    }

    //    if (ThirdPersonCam.CamStyle == ThirdPersonCam.CameraStyle.Combat)
    //    {
    //        if (!_crossHair.gameObject.activeInHierarchy)
    //        {
    //            _crossHair.gameObject.SetActive(true);
    //        }
    //    }
    //}
}
