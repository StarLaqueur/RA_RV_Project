using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRGuns : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] XRBaseController shooterXRController;
    [SerializeField] Transform raycastOrigin;
    public GameObject impactEffect;
    public ParticleSystem muzzleflash;
    public PlayerVRPrefab playerVRPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Shoot()
    {
        muzzleflash.Play();
        shooterXRController.SendHapticImpulse(0.5f, 0.25f);
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit))
        {
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
            
            playerVRPrefab.ShootVR(hit.point, hit.normal);
           
        }
    }
}