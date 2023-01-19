using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System;
using Photon.Realtime;

public class ThirdPersonInit : MonoBehaviourPunCallbacks
{
    PhotonView view;
    public GameObject localCam, cinemachineCam, playerGFX, aimCam, affixGun, prefabThird, impactEffectScientist, impactEffectVirus;
    public CharacterController controller3RD;
    public Guns gunScript;
    public PlayerController playerController;
    

    public AudioSource shotSound;
    public AudioSource isHitSound;
    public AudioSource respawnSound;

    private string thirdPersonMask = "ThirdPersonMask";
    //public float currentHealth = 10;
    //public float maxHealth = 10;

    NetworkPlayerSpawn networkPlayerSpawn;

    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] Image healthBarImage;
    [SerializeField] GameObject ui;


    public ParticleSystem[] particle_effects_virus;
    public Light beam_light_virus;
    public ParticleSystem[] particle_effects_scientist;
    public Light beam_light_scientist;
    public float currentHealth;
    public float maxHealth;
    public string json_gamerules;
    public float master_Health;
    public float nextTimeToFire;
    public float master_shot_cd;
    public float master_scientist_color;
    public float scientist_color;
    public float master_virus_color;
    public float virus_color;
    public float number_kills;
    public float master_number_kills;

    public JSON_Format object_gamerules;
    public GameRules gamerules = new GameRules();

    public PlayerVRPrefab playerVR;
 

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        networkPlayerSpawn = PhotonView.Find((int)view.InstantiationData[0]).GetComponent<NetworkPlayerSpawn>();

        
        if (PhotonNetwork.IsMasterClient)
        {
            //Debug.Log("enter master rhird");
            json_gamerules = gamerules.gamerules_read();
            object_gamerules = JsonUtility.FromJson<JSON_Format>(json_gamerules);
            master_Health = object_gamerules.HP;
            master_shot_cd = object_gamerules.Shot_Cooldown;
            master_scientist_color = object_gamerules.Scientist_Color;
            master_number_kills = object_gamerules.Shot_Cooldown;

            currentHealth = master_Health;
            maxHealth = master_Health;
            nextTimeToFire = master_shot_cd;
            scientist_color = master_scientist_color;
            number_kills = master_number_kills;

            master_virus_color = object_gamerules.Virus_Color;
            virus_color = master_virus_color;

            ReadHealth(master_Health);
            ReadShotCD(master_shot_cd);

            ReadColorScientist(master_scientist_color);
            Scientist_Color_shots();

        }

        if (view.IsMine)
        {
            respawnSound.Play();
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
            gameObject.layer = LayerMask.NameToLayer(thirdPersonMask);
            playerGFX.layer = LayerMask.NameToLayer(thirdPersonMask);
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

        isHitSound.Play();
        currentHealth -= damage;
        healthBarImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
            Debug.Log("Death");        
        }
    }

    private void Die()
    {
        PlayerKilled();
        networkPlayerSpawn.Die();
    }

    public void ShootThirdPerson(Vector3 hitPosition, Vector3 hitNormal)
    {
        view.RPC("RPC_Shoot", RpcTarget.All, hitPosition, hitNormal);
    }

    [PunRPC]
    void RPC_Shoot(Vector3 hitPosition, Vector3 hitNormal)
    {
        GameObject impactGO = Instantiate(impactEffectScientist, hitPosition, Quaternion.LookRotation(hitNormal));
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


    public void ReadHealth(float health)
    {
        view.RPC("RPC_ReadHealth", RpcTarget.OthersBuffered, health);
    }

    [PunRPC]
    void RPC_ReadHealth(float health)
    {
        currentHealth = health;
        maxHealth = health;
        //Debug.Log("masters"+currentHealth);
    }

    public void ReadShotCD(float time_fire)
    {
        //Debug.Log("test cooldown");
        view.RPC("RPC_ReadShotCD", RpcTarget.OthersBuffered, time_fire);
        return;
    }
    [PunRPC]
    void RPC_ReadShotCD(float time_fire)
    {
        nextTimeToFire = time_fire;
        //Debug.Log("masters cooldown RPC" + nextTimeToFire);
    }
    public void ReadColorScientist(float color)
    {
        //Debug.Log("test color : "+color);
        view.RPC("RPC_ReadColorScientist", RpcTarget.OthersBuffered, color);
    }
    [PunRPC]
    void RPC_ReadColorScientist(float color)
    {
        scientist_color = color;
        Scientist_Color_shots();
        //Debug.Log("masters colors RPC" + scientist_color);
    }

    public void ReadNumberKills(float number_kills)
    {
        //Debug.Log("test color : "+color);
        view.RPC("RPC_NumberKills", RpcTarget.OthersBuffered, number_kills);
    }
    [PunRPC]
    void RPC_ReadNumberKills(float color)
    {
        scientist_color = color;
        Scientist_Color_shots();
        //Debug.Log("masters colors RPC" + scientist_color);
    }

    public void Scientist_Color_shots()
    {
        //Debug.Log("bonjour je suis un test");
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

    public void Virus_Color_shots(float color)
    {
        Debug.Log("je suis un test pour la coloration du virus pour le scientifique par le scientifique "+virus_color);
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


    public void PlayerKilled()
    {
        view.RPC("RPC_PlayerKilled", RpcTarget.All);
    }

    [PunRPC]
    void RPC_PlayerKilled()
    {
        GameManagement.VRTeam++;
    }

}
