using UnityEngine;
using Photon.Pun;


public class ThirdPersonInit : MonoBehaviourPunCallbacks
{
    PhotonView view;
    public GameObject localCam, cinemachineCam, playerGFX, aimCam, affixGun, shootPoint, prefabThird;
    public CharacterController controller3RD;
    public PlayerController playerController;
    private string remoteLayerName = "RemotePlayer";
    
   
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            prefabThird.SetActive(true);
            localCam.SetActive(true);
            cinemachineCam.SetActive(true);
            playerGFX.SetActive(true);
            aimCam.SetActive(true);
            shootPoint.SetActive(true);
            affixGun.SetActive(true);

            controller3RD.enabled = true;
            playerController.enabled = true;

            
        } else
        {
            gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
        }
    }

    public void TakeDamageGo(float damage)
    {
        view.RPC("RPC_TakeDamage", RpcTarget.All, damage);

    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (!view.IsMine)
        {
            return;
        }
        Debug.Log(damage + "shes");
    }




}
