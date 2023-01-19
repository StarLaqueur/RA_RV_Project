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
    //public float currentHealth = 10;
    //public float maxHealth = 10;


    public ParticleSystem[] particle_effects_scientist;
    public Light beam_light_scientist;
    public float currentHealth;
    public float maxHealth;
    public string json_gamerules;
    public float master_Health;
    public float nextTimeToFire;
    public float master_shot_cd;
    public float master_virus_color;
    public float virus_color;
    public bool master_is_third_person = false;
    public JSON_Format object_gamerules;
    public GameRules gamerules = new GameRules();

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

        if (PhotonNetwork.IsMasterClient)
        {
            //Debug.Log("enter master");
            json_gamerules = gamerules.gamerules_read();
            object_gamerules = JsonUtility.FromJson<JSON_Format>(json_gamerules);
            master_Health = object_gamerules.HP;
            master_shot_cd = object_gamerules.Shot_Cooldown;
            master_virus_color = object_gamerules.Scientist_Color;
            currentHealth = master_Health;
            maxHealth = master_Health;
            nextTimeToFire = master_shot_cd;
            virus_color = master_virus_color;

            ReadHealth_VR(master_Health);
            ReadShotCD_VR(master_shot_cd);
            ReadColorVirus(master_virus_color);
            Virus_Color_shots();
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
        yield return new WaitForSeconds(nextTimeToFire);
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

    public void ReadHealth_VR(float health)
    {
        view.RPC("RPC_ReadHealth_VR", RpcTarget.OthersBuffered, health);
    }

    [PunRPC]
    void RPC_ReadHealth_VR(float health)
    {
        currentHealth = health;
        maxHealth = health;
        //Debug.Log("masters"+currentHealth);
    }

    public void ReadShotCD_VR(float time_fire)
    {
        //Debug.Log("test cooldown");
        view.RPC("RPC_ReadShotCD_VR", RpcTarget.OthersBuffered, time_fire);
        return;
    }
    [PunRPC]
    void RPC_ReadShotCD_VR(float time_fire)
    {
        nextTimeToFire = time_fire;
        //Debug.Log("masters cooldown RPC" + nextTimeToFire);
    }
    public void ReadColorVirus(float color)
    {
        //Debug.Log("test color : "+color);
        view.RPC("RPC_ReadColorVirus", RpcTarget.OthersBuffered, color);
    }
    [PunRPC]
    void RPC_ReadColorVirus(float color)
    {
        Virus_Color_shots();
        virus_color = color;
        //Debug.Log("masters colors RPC" + scientist_color);

    }

    public void Virus_Color_shots()
    {
        particle_effects_scientist = impactEffect.GetComponentsInChildren<ParticleSystem>();
        beam_light_scientist = impactEffect.GetComponentInChildren<Light>();
        var main0 = particle_effects_scientist[0].main;
        var main1 = particle_effects_scientist[1].main;
        var main2 = muzzleFlash.main;
        main0.startColor = gamerules.GetColorScientist(virus_color);
        main1.startColor = gamerules.GetColorScientist(virus_color);
        main2.startColor = gamerules.GetColorScientist(virus_color);
        beam_light_scientist.color = gamerules.GetColorScientist(virus_color);
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(gamerules.GetColorScientist(virus_color), 0.0f), new GradientColorKey(gamerules.GetColorScientist(virus_color), 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        var col1 = particle_effects_scientist[0].colorOverLifetime;
        var col2 = particle_effects_scientist[1].colorOverLifetime;
        var col3 = muzzleFlash.colorOverLifetime;
        col1.color = grad;
        col2.color = grad;
        col3.color = grad;
    }
}
