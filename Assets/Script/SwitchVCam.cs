using UnityEngine;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera defaultCam;
    [SerializeField] private CinemachineVirtualCamera aimCam;

    void Start()
    {
        defaultCam.enabled = true; //true
        aimCam.enabled = false; //false
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            defaultCam.enabled = false;
            aimCam.enabled = true;
        }
        else
        {
            defaultCam.enabled = true;
            aimCam.enabled = false;
        }

    }
}