using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class FreezeCamera : MonoBehaviour
{
    public Toggle freezeToggle;
    public GameObject Camera;

    void Start()
    {
        //when toggle change call FreezeCameraOnToggle function
        freezeToggle.GetComponent<Toggle>().isOn = false;
        freezeToggle.onValueChanged.AddListener(FreezeCameraOnToggle);
    }

    //If toggle state is false freeze the camera
    void FreezeCameraOnToggle(bool value)
    {
        if (value)
        {
            Camera.GetComponent<VuforiaBehaviour>().enabled = false;
        }
        else
        {
            Camera.GetComponent<VuforiaBehaviour>().enabled = true;
        }
    }
}