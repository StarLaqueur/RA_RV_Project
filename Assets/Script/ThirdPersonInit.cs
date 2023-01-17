using UnityEngine;
using Photon.Pun;


public class ThirdPersonInit : MonoBehaviourPunCallbacks
{
    PhotonView view;
    public GameObject localCam, cinemachineCam, playerGFX, aimCam, affixGun, prefabThird, impactEffect;
    public CharacterController controller3RD;
    public Guns gunScript;
    public PlayerController playerController;
    private string remoteLayerName = "RemotePlayer";
    NetworkPlayerSpawn networkPlayerSpawn;

    public float currentHealth;
    public string json_gamerules;
    public float master_Health;
    public float nextTimeToFire;
    public float master_shot_cd;
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
            nextTimeToFire = master_shot_cd;
            view.RPC("RPC_ReadHealth", RpcTarget.OthersBuffered, master_Health);
            ReadShotCD(master_shot_cd);
            currentHealth = master_Health;
        }
        //Debug.Log("current-health " + currentHealth);

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
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    [PunRPC]
    void RPC_ReadHealth(float health)
    {
        currentHealth = health;
        //Debug.Log("masters"+currentHealth);
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

    public void ReadShotCD(float time_fire)
    {
        Debug.Log("test cooldown");
        view.RPC("RPC_ReadShotCD", RpcTarget.OthersBuffered, time_fire); 
    }
    [PunRPC]
    void RPC_ReadShotCD(float time_fire)
    {
        nextTimeToFire = time_fire;
        Debug.Log("masters cooldown RPC" + nextTimeToFire);
    }



}
