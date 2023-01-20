using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRGuns : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] XRBaseController shooterXRController;
    [SerializeField] private LayerMask remotePlayerMask;
    [SerializeField] Transform raycastOrigin;
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
        playerVRPrefab.ShootParticule();
        shooterXRController.SendHapticImpulse(0.5f, 0.25f);
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, remotePlayerMask))
        {
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
            playerVRPrefab.ShootVR(hit.point, hit.normal);
        }
    }

    IEnumerator WaitReload()
    {
        authorizedToShoot = false;
        yield return new WaitForSeconds(playerVRPrefab.nextTimeToFire);
        authorizedToShoot = true;
    }
}
