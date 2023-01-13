using UnityEngine;

public class SwitchVCam : MonoBehaviour
{
    public int PriorityBoostAmount = 10;
    //public GameObject Reticle;

    Cinemachine.CinemachineVirtualCameraBase vcam;
    bool boosted = false;

    void Start()
    {
        vcam = GetComponent<Cinemachine.CinemachineVirtualCameraBase>();
    }

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
                }
            }
            else if (boosted)
            {
                vcam.Priority -= PriorityBoostAmount;
                boosted = false;
            }
        }
        /*if (Reticle != null)
            Reticle.SetActive(boosted);*/
    }
}
