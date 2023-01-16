using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public GameObject impactEffect;


    [SerializeField] private LayerMask remotePlayerMask;
    [SerializeField] Camera thirdCamera;
    [SerializeField] int damage;

    private float nextTimeToFire = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }
    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(thirdCamera.transform.position, thirdCamera.transform.forward, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
