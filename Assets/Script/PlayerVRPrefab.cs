using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.XR;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerVRPrefab : MonoBehaviourPunCallbacks, IDamageable
{
    PhotonView view;
    NetworkPlayerSpawn networkPlayerSpawn;

    public GameObject locomotionSys, body, impactEffect;
    
    public Camera cameraVR;
    public ActionBasedController xrControllerLeft, xrControllerRight;
    public TrackedPoseDriver tracketDriver;
    public AudioListener audioCamera;
    public XRRayInteractor xrayLeft, xrayRight;
    public XRInteractorLineVisual xrayInteractorLeft, xrayInteractorRight;
    public CharacterController playerVrCharacterController;
    public InputActionProperty shootActionButton;
    public VRGuns vrGunScript;
    private bool authorizedToShoot = true;

    private string vrPlayerMask = "vrPlayerMask";
    public float currentHealth = 10;
    public float maxHealth = 10;

    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] Image healthBarImage;
    [SerializeField] GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        networkPlayerSpawn = PhotonView.Find((int)view.InstantiationData[0]).GetComponent<NetworkPlayerSpawn>();

        if (view.IsMine)
        {
            body.SetActive(false);
            GetComponent<XROrigin>().enabled = true;
            GetComponentInChildren<CharacterControllerDriver>().enabled = true;
            playerVrCharacterController.enabled = true;
            locomotionSys.SetActive(true);
           

            cameraVR.enabled = true;
            tracketDriver.enabled = true;
            audioCamera.enabled = true;

            xrayLeft.enabled = true;
            xrayRight.enabled = true;

            xrayInteractorLeft.enabled = true;
            xrayInteractorRight.enabled = true;

            xrControllerLeft.enabled = true;
            xrControllerRight.enabled = true;

            vrGunScript.enabled = true;

            GameObject.Find("Floor").GetComponent<TeleportationArea>().teleportationProvider = locomotionSys.GetComponent<TeleportationProvider>();

        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer(vrPlayerMask);
            Destroy(ui);
        }
 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shootActionButton.action.ReadValue<float>() > 0.1f && authorizedToShoot)
        {
            vrGunScript.Shoot();
            
            StartCoroutine(WaitReload());
        }
    }
    
    IEnumerator WaitReload()
    {
        authorizedToShoot = false;
        yield return new WaitForSeconds(1.5f);
        authorizedToShoot = true;
    }

    public void TakeDamage(float damage)
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

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        networkPlayerSpawn.Die();
    }

    public void ShootVR(Vector3 hitPosition, Vector3 hitNormal)
    {
        view.RPC("RPC_Shoot", RpcTarget.All, hitPosition, hitNormal);
    }

    [PunRPC]
    void RPC_Shoot(Vector3 hitPosition, Vector3 hitNormal)
    {
        GameObject impactGO = Instantiate(impactEffect, hitPosition, Quaternion.LookRotation(hitNormal));
        
        Destroy(impactGO, 2f);
    }
    public void ShootParticule()
    {
        view.RPC("RPC_ShootParticule", RpcTarget.All);
    }

    [PunRPC]
    void RPC_ShootParticule()
    {
        muzzleFlash.Play();
    }
}
