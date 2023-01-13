using UnityEngine;
using Photon.Pun;


public class ThirdPersonInit : MonoBehaviour
{
    PhotonView view;
    public GameObject localCam, cinemachineCam, playerGFX, aimCam;
    public CharacterController controller3RD;
    public MovementPlayer movementPlayer;
    public SwitchVCam vcam;
    
   
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            localCam.SetActive(true);
            cinemachineCam.SetActive(true);
            playerGFX.SetActive(true);
            aimCam.SetActive(true);

            controller3RD.enabled = true;
            movementPlayer.enabled = true;
            vcam.enabled = true;
        }
    }


}
