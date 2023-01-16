using UnityEngine;
using Photon.Pun;


public class ThirdPersonInit : MonoBehaviourPunCallbacks
{
    PhotonView view;
    public GameObject localCam, cinemachineCam, playerGFX, aimCam, affixGun, prefabThird, impactEffect;
    public CharacterController controller3RD;
    public MovementPlayer movementPlayer;
    public Guns gunScript;
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
            affixGun.SetActive(true);

            controller3RD.enabled = true;
            movementPlayer.enabled = true;
            gunScript.enabled = true;

            
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

    public void ShootThirdPerson(Vector3 hitPosition, Vector3 hitNormal)
    {
        view.RPC("RPC_Shoot", RpcTarget.All, hitPosition, hitNormal);
    }

    [PunRPC]
    void RPC_Shoot(Vector3 hitPosition, Vector3 hitNormal)
    {
        GameObject impactGO = Instantiate(impactEffect, hitPosition, Quaternion.LookRotation(hitNormal));
        Destroy(impactGO, 2f);
    }




}
