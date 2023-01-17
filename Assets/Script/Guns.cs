using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Guns : MonoBehaviour
{
    public GameObject impactEffect;
    public ThirdPersonInit thirdPersonScript;
    PhotonView view;

    [SerializeField] private LayerMask remotePlayerMask;
    [SerializeField] Camera thirdCamera;
    [SerializeField] int damage;
    public ParticleSystem muzzleflash;
    private bool authorizedToShoot = true;
    public float nextTimeToFire;
    public string json_gamerules;
    public JSON_Format object_gamerules;
    public GameRules gamerules = new GameRules();
    public float master_shot_cd;


    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("enter master");
            json_gamerules = gamerules.gamerules_read();
            object_gamerules = JsonUtility.FromJson<JSON_Format>(json_gamerules);
            master_shot_cd = object_gamerules.HP;
            view.RPC("RPC_ReadShotCD", RpcTarget.OthersBuffered, master_shot_cd);
            nextTimeToFire = master_shot_cd;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && authorizedToShoot)
        {
            Shoot();
            StartCoroutine(WaitReload());
        }

    }
    private void Shoot()
    {
        muzzleflash.Play();
        RaycastHit hit;
        if (Physics.Raycast(thirdCamera.transform.position, thirdCamera.transform.forward, out hit))
        {
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
            Debug.Log(hit.collider.gameObject.name);
            thirdPersonScript.ShootThirdPerson(hit.point, hit.normal);
        }
    }
    IEnumerator WaitReload()
    {
        authorizedToShoot = false;
        yield return new WaitForSeconds(nextTimeToFire);
        authorizedToShoot = true;
    }
    [PunRPC]
    void RPC_ReadShotCD(float time_fire)
    {
        nextTimeToFire = time_fire;
        Debug.Log("masters" + nextTimeToFire);
    }
}
