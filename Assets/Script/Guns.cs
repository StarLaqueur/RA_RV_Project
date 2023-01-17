using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Guns : MonoBehaviour
{
    public GameObject impactEffect;
    public ThirdPersonInit thirdPersonScript;

    [SerializeField] private LayerMask remotePlayerMask;
    [SerializeField] Camera thirdCamera;
    [SerializeField] int damage;
    public ParticleSystem muzzleflash;

    private bool authorizedToShoot = true;
    AudioSource source;
    void Start()
    {

        Debug.Log("shot_cd" + thirdPersonScript.nextTimeToFire);
        //source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && authorizedToShoot)
        {
            //source = GetComponent<AudioSource>();
            Shoot();
            //source.Play();
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
        yield return new WaitForSeconds(thirdPersonScript.nextTimeToFire);
        authorizedToShoot = true;
    }

}
