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

    public GameObject locomotionSys, body, impactEffectScientist, impactEffectVirus;
    public Camera cameraVR;
    public ActionBasedController xrControllerLeft, xrControllerRight;
    public TrackedPoseDriver tracketDriver;
    public AudioListener audioCamera;
    public XRRayInteractor xrayLeft, xrayRight;
    public XRInteractorLineVisual xrayInteractorLeft, xrayInteractorRight;
    public CharacterController playerVrCharacterController;
    public InputActionProperty teleportationButton;

    public VRGuns vrGunScript;
    public AudioSource shotSound;
    public AudioSource isHit;
    public AudioSource respawnSound;
   

    private string vrPlayerMask = "vrPlayerMask";

    //Defines the needed particle systems for the coloration of the scientist's and virus's shots
    public ParticleSystem[] particle_effects_virus;
    public Light beam_light_virus;
    public ParticleSystem[] particle_effects_scientist;
    public Light beam_light_scientist;

    //Defines the data needed to implement the host's choice of game parameters to the other players
    private float currentHealth;
    private float maxHealth;
    private string json_gamerules;
    private float master_Health;
    public float nextTimeToFire;
    private float master_shot_cd;
    private float master_virus_color;
    private float virus_color;
    private float master_scientist_color;
    private float scientist_color;

    //Define the objects needed to read the JSON SaveData
    public JSON_Format object_gamerules;
    public GameRules gamerules = new GameRules();

    [SerializeField] private ParticleSystem muzzleFlash, teleportationParticules;
    [SerializeField] Image healthBarImage;
    [SerializeField] GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        networkPlayerSpawn = PhotonView.Find((int)view.InstantiationData[0]).GetComponent<NetworkPlayerSpawn>();

        if (view.IsMine)
        {
            respawnSound.Play();
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

        //If the player is the Master, reads the JSON data and instantiate RPC for every player to get these data
        if (PhotonNetwork.IsMasterClient)
        {
            //References the JSON to read
            json_gamerules = gamerules.gamerules_read();
            object_gamerules = JsonUtility.FromJson<JSON_Format>(json_gamerules);

            //Extract the data from the JSON and stores it in variables
            master_Health = object_gamerules.HP;
            master_shot_cd = object_gamerules.Shot_Cooldown;
            master_virus_color = object_gamerules.Virus_Color;
            master_scientist_color = object_gamerules.Scientist_Color;
            scientist_color = master_scientist_color;
            currentHealth = master_Health;
            maxHealth = master_Health;
            nextTimeToFire = master_shot_cd;
            virus_color = master_virus_color;

            //Call the functions to instantiate the RPC needed to give the correct values to every player
            ReadHealth_VR(master_Health);
            ReadShotCD_VR(master_shot_cd);
            ReadColorScientist(scientist_color);
            Scientist_Color_shots();
            ReadColorVirus(master_virus_color);
            Virus_Color_shots(master_virus_color);
        }

    }

    void FixedUpdate()
    {
        if (teleportationButton.action.ReadValue<float>() > 0.1f)
        {
            view.RPC("RPC_TeleportationParticule", RpcTarget.All);

        }
    }

    [PunRPC]
    void RPC_TeleportationParticule()
    {
        teleportationParticules.Play();
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

        isHit.Play();
        currentHealth -= damage;
        healthBarImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerKilled();
        networkPlayerSpawn.Die();
    }

    public void ShootVR(Vector3 hitPosition, Vector3 hitNormal)
    {
        view.RPC("RPC_ShootVR", RpcTarget.All, hitPosition, hitNormal);
    }

    [PunRPC]
    void RPC_ShootVR(Vector3 hitPosition, Vector3 hitNormal)
    {
        GameObject impactGO = Instantiate(impactEffectVirus, hitPosition, Quaternion.LookRotation(hitNormal));
        
        Destroy(impactGO, 2f);
    }

    public void ShootParticule()
    {
        view.RPC("RPC_ShootParticule", RpcTarget.All);
    }

    [PunRPC]
    void RPC_ShootParticule()
    {
        shotSound.Play();
        muzzleFlash.Play();
    }

    //Transfers the health value decided by the Master to every player
    public void ReadHealth_VR(float health)
    {
        view.RPC("RPC_ReadHealth_VR", RpcTarget.OthersBuffered, health);
    }

    [PunRPC]
    void RPC_ReadHealth_VR(float health)
    {
        currentHealth = health;
        maxHealth = health;
    }
    //Transfers the shot cooldown decided by the Master to every player
    public void ReadShotCD_VR(float time_fire)
    {
        view.RPC("RPC_ReadShotCD_VR", RpcTarget.OthersBuffered, time_fire);
        return;
    }

    [PunRPC]
    void RPC_ReadShotCD_VR(float time_fire)
    {
        nextTimeToFire = time_fire;
    }
    //Transfers the virus color decided by the Master to every player
    public void ReadColorVirus(float color)
    {
        view.RPC("RPC_ReadColorVirus", RpcTarget.OthersBuffered, color);
    }

    [PunRPC]

    void RPC_ReadColorVirus(float color)
    {
        Virus_Color_shots(color);
        virus_color = color;

    }
    //Transfers the scientist color decided by the Master to every player
    public void ReadColorScientist(float color)
    {
        view.RPC("RPC_ReadColorScientist", RpcTarget.OthersBuffered, color);
    }

    [PunRPC]
    void RPC_ReadColorScientist(float color)
    {
        scientist_color = color;
        Scientist_Color_shots();
    }

    //Change the color of the prefab corresponding to the particles of the virus's shots
    public void Virus_Color_shots(float color)
    {
        virus_color = color;
        particle_effects_virus = impactEffectVirus.GetComponentsInChildren<ParticleSystem>();
        beam_light_virus = impactEffectVirus.GetComponentInChildren<Light>();
        var main0 = particle_effects_virus[0].main;
        var main1 = particle_effects_virus[1].main;
        var main2 = muzzleFlash.main;
        main0.startColor = gamerules.GetColorVirus(virus_color);
        main1.startColor = gamerules.GetColorVirus(virus_color);
        main2.startColor = gamerules.GetColorVirus(virus_color);
        beam_light_virus.color = gamerules.GetColorVirus(virus_color);
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(gamerules.GetColorVirus(virus_color), 0.0f), new GradientColorKey(gamerules.GetColorVirus(virus_color), 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        var col1 = particle_effects_virus[0].colorOverLifetime;
        var col2 = particle_effects_virus[1].colorOverLifetime;
        var col3 = muzzleFlash.colorOverLifetime;
        col1.color = grad;
        col2.color = grad;
        col3.color = grad;
    }
    //Change the color of the prefab corresponding to the particles of the virus's shots
    public void Scientist_Color_shots()
    {
        particle_effects_scientist = impactEffectScientist.GetComponentsInChildren<ParticleSystem>();
        beam_light_scientist = impactEffectScientist.GetComponentInChildren<Light>();
        var main0 = particle_effects_scientist[0].main;
        var main1 = particle_effects_scientist[1].main;
        var main2 = muzzleFlash.main;
        main0.startColor = gamerules.GetColorScientist(scientist_color);
        main1.startColor = gamerules.GetColorScientist(scientist_color);
        main2.startColor = gamerules.GetColorScientist(scientist_color);
        beam_light_scientist.color = gamerules.GetColorScientist(scientist_color);
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(gamerules.GetColorScientist(scientist_color), 0.0f), new GradientColorKey(gamerules.GetColorScientist(scientist_color), 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        var col1 = particle_effects_scientist[0].colorOverLifetime;
        var col2 = particle_effects_scientist[1].colorOverLifetime;
        var col3 = muzzleFlash.colorOverLifetime;
        col1.color = grad;
        col2.color = grad;
        col3.color = grad;
    }
    public void PlayerKilled()
    {
        view.RPC("RPC_PlayerKilled", RpcTarget.All);
    }

    [PunRPC]
    void RPC_PlayerKilled()
    {
        GameManagement.TPPTeam++;

    }
}