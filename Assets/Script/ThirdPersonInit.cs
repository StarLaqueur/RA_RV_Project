using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;


public class ThirdPersonInit : MonoBehaviourPunCallbacks
{
    PhotonView view;
    public GameObject localCam, cinemachineCam, playerGFX, aimCam, affixGun, prefabThird, impactEffect;
    [SerializeField] Image healthBarImage;
    [SerializeField] GameObject ui;
    public CharacterController controller3RD;
    public Guns gunScript;
    public PlayerController playerController;
    private string remoteLayerName = "RemotePlayer";
    public float currentHealth = 10;
    public float maxHealth = 10;


    NetworkPlayerSpawn networkPlayerSpawn;


    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        networkPlayerSpawn = PhotonView.Find((int)view.InstantiationData[0]).GetComponent<NetworkPlayerSpawn>();
        

        if (view.IsMine)
        {
            prefabThird.SetActive(true);
            localCam.SetActive(true);
            cinemachineCam.SetActive(true);
            playerGFX.SetActive(true);
            aimCam.SetActive(true);
            affixGun.SetActive(true);

            controller3RD.enabled = true;
            gunScript.enabled = true;
            playerController.enabled = true;

            
        } else
        {
            gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
            Destroy(ui);
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

        currentHealth -= damage;

        healthBarImage.fillAmount = currentHealth / maxHealth;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Coucou c'est charlou
        networkPlayerSpawn.Die();
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
