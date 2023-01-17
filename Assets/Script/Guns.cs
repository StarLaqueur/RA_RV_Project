using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public ThirdPersonInit thirdPersonScript;

    [SerializeField] private LayerMask remotePlayerMask;
    [SerializeField] Camera thirdCamera;
    [SerializeField] int damage;
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
        RaycastHit hit;
        if (Physics.Raycast(thirdCamera.transform.position, thirdCamera.transform.forward, out hit, Mathf.Infinity, remotePlayerMask))
        {
            Debug.Log(hit.collider.gameObject.name);
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
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
