using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRGuns : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] XRBaseController shooterXRController;
    [SerializeField] private LayerMask remotePlayerMask;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] Image reloadBar;
    public PlayerVRPrefab playerVRPrefab;
    private bool authorizedToShoot = true;
    public InputActionProperty shootActionButton;

    void Update()
    {
        if (shootActionButton.action.ReadValue<float>() > 0.1f && authorizedToShoot)
        {
            Shoot();
            StartCoroutine(WaitReload());
        }
    }

    public void Shoot()
    {
        //When the trigger is pressed, called ShootParticule function and send Haptic impulse in the controller of the player
        playerVRPrefab.ShootParticule();
        shooterXRController.SendHapticImpulse(0.5f, 0.25f);
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, remotePlayerMask))
        {
            //When the raycast hit a GameObject with the interface IDamageable, does damage to the GameObject
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
            playerVRPrefab.ShootVR(hit.point, hit.normal);
        }
    }

    IEnumerator WaitReload()
    {
        //Define the time between each shots

        authorizedToShoot = false;
        reloadBar.fillAmount = 0;
        yield return new WaitForSeconds(playerVRPrefab.nextTimeToFire);
        reloadBar.fillAmount = 1;
        authorizedToShoot = true;
        
    }
}
