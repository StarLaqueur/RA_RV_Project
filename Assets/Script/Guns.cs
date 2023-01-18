using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public GameObject impactEffect;
    public ThirdPersonInit thirdPersonScript;
    public AudioSource shotSound;


    [SerializeField] private LayerMask remotePlayerMask;
    [SerializeField] Camera thirdCamera;
    [SerializeField] int damage;
    public ParticleSystem muzzleflash;
    private bool authorizedToShoot = true;

    void Start()
    {

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
        thirdPersonScript.ShootParticule();
        shotSound.Play();
        RaycastHit hit;
        if (Physics.Raycast(thirdCamera.transform.position, thirdCamera.transform.forward, out hit, Mathf.Infinity, remotePlayerMask))
        {
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
            Debug.Log(hit.collider.gameObject.name);
            thirdPersonScript.ShootThirdPerson(hit.point, hit.normal);
        }
    }
    IEnumerator WaitReload()
    {
        authorizedToShoot = false;
        yield return new WaitForSeconds(1.5f);
        authorizedToShoot = true;
    }
}
