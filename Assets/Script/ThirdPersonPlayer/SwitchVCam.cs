using UnityEngine;

public class SwitchVCam : MonoBehaviour
{
    public int PriorityBoostAmount = 10;

    Cinemachine.CinemachineVirtualCameraBase vcam;
    [SerializeField] private Canvas thirdPersonCanvas;
    [SerializeField] private Canvas aimCanvas;
    bool boosted = false;

    // Activation of the cinemachine camera
    void Start()
    {
        vcam = GetComponent<Cinemachine.CinemachineVirtualCameraBase>();
    }

    // Camera management and setting up the zoom
    void Update()
    {
        if (vcam != null)
        {
            if (Input.GetMouseButton(1))
            {
                if (!boosted)
                {
                    vcam.Priority += PriorityBoostAmount;
                    boosted = true;
                    thirdPersonCanvas.enabled = false;
                    aimCanvas.enabled = true;
                }
            }
            else if (boosted)
            {
                vcam.Priority -= PriorityBoostAmount;
                boosted = false;
                thirdPersonCanvas.enabled = true;
                aimCanvas.enabled = false;
            }
        }
    }
}
