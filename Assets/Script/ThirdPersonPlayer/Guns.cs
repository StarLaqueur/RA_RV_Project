using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guns : MonoBehaviour
{
    public ThirdPersonInit thirdPersonScript;
    [SerializeField] private LayerMask remotePlayerMask;
    [SerializeField] Camera thirdCamera;
    [SerializeField] int damage;
    [SerializeField] Image reloadBar;
    private bool authorizedToShoot = true;

    // Checking the shooting torch and if the player can shoot to invoke the Shoot function
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && authorizedToShoot)
        {
            Shoot();
            StartCoroutine(WaitReload());
        }
    }

    // Activate particles
    // Shooting with the raycast
    private void Shoot()
    {
        thirdPersonScript.ShootParticule();
        RaycastHit hit;
        if (Physics.Raycast(thirdCamera.transform.position, thirdCamera.transform.forward, out hit, Mathf.Infinity, remotePlayerMask))
        {
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
            thirdPersonScript.ShootThirdPerson(hit.point, hit.normal);
        }
    }

    //Weapon reload coroutine
    IEnumerator WaitReload()
    {
        authorizedToShoot = false;
        reloadBar.fillAmount = 0;
        yield return new WaitForSeconds(thirdPersonScript.nextTimeToFire);
        reloadBar.fillAmount = 1;
        authorizedToShoot = true;
        
    }
}
