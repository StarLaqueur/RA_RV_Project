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

    public AudioSource shotSound;
    public AudioSource isHitSound;
    public AudioSource respawnSound;

    private string thirdPersonMask = "ThirdPersonMask";
    public float currentHealth = 10;
    public float maxHealth = 10;

    NetworkPlayerSpawn networkPlayerSpawn;

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
        shotSound.Play();
        muzzleFlash.Play();
        
    }




}
