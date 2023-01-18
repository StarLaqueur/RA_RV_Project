using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class ThirdPersonInit : MonoBehaviourPunCallbacks
{
    PhotonView view;
    public GameObject localCam, cinemachineCam, playerGFX, aimCam, affixGun, prefabThird, impactEffect;
    public CharacterController controller3RD;
    public Guns gunScript;
    public PlayerController playerController;

    private string thirdPersonMask = "ThirdPersonMask";
    //public float currentHealth = 10;
    //public float maxHealth = 10;

    NetworkPlayerSpawn networkPlayerSpawn;

    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] Image healthBarImage;
    [SerializeField] GameObject ui;

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
    public JSON_Format object_gamerules;
    public GameRules gamerules = new GameRules();
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        networkPlayerSpawn = PhotonView.Find((int)view.InstantiationData[0]).GetComponent<NetworkPlayerSpawn>();

        if (PhotonNetwork.IsMasterClient)
        {
            //Debug.Log("enter master");
            json_gamerules = gamerules.gamerules_read();
            object_gamerules = JsonUtility.FromJson<JSON_Format>(json_gamerules);
            master_Health = object_gamerules.HP;
            master_shot_cd = object_gamerules.Shot_Cooldown;
            master_scientist_color = object_gamerules.Scientist_Color;
            currentHealth = master_Health;
            maxHealth = master_Health;
            nextTimeToFire = master_shot_cd;
            scientist_color = master_scientist_color;

            ReadHealth(master_Health);
            ReadShotCD(master_shot_cd);
            ReadColorScientist(master_scientist_color);
        }

        Scientist_Color_shots(scientist_color);


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
    public void ShootParticule()
    {
        view.RPC("RPC_ShootParticule", RpcTarget.All);
    }

    [PunRPC]
    void RPC_ShootParticule()
    {
        muzzleFlash.Play();
    }



    public void ReadHealth(float health)
    {
        //Debug.Log("test cooldown");
        view.RPC("RPC_ReadHealth", RpcTarget.OthersBuffered, health);
    }

    [PunRPC]
    void RPC_ReadHealth(float health)
    {
        currentHealth = health;
        //Debug.Log("masters"+currentHealth);
    }

    public void ReadShotCD(float time_fire)
    {
        //Debug.Log("test cooldown");
        view.RPC("RPC_ReadShotCD", RpcTarget.OthersBuffered, time_fire);
    }
    [PunRPC]
    void RPC_ReadShotCD(float time_fire)
    {
        nextTimeToFire = time_fire;
        //Debug.Log("masters cooldown RPC" + nextTimeToFire);
    }
    public void ReadColorScientist(float color)
    {
        Debug.Log("test color");
        view.RPC("RPC_ReadShotCD", RpcTarget.OthersBuffered, color);
    }
    [PunRPC]
    void RPC_ReadColorScientist(float color)
    {
        scientist_color = color;
        Debug.Log("masters cooldown RPC" + scientist_color);
    }

    public void Scientist_Color_shots(float scientist)
    {
        particle_effects_scientist = impactEffect.GetComponentsInChildren<ParticleSystem>();
        beam_light_scientist = impactEffect.GetComponentInChildren<Light>();
        var main0 = particle_effects_scientist[0].main;
        var main1 = particle_effects_scientist[1].main;
        main0.startColor = gamerules.GetColorScientist(scientist_color);
        main1.startColor = gamerules.GetColorScientist(scientist_color);
        beam_light_scientist.color = gamerules.GetColorScientist(scientist_color);
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(gamerules.GetColorScientist(scientist_color), 0.0f), new GradientColorKey(gamerules.GetColorScientist(scientist_color), 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        var col = particle_effects_scientist[0].colorOverLifetime;
        col.color = grad;
    }

}
