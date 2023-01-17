using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{ 
    [SerializeField] public const float maxHealth = 10;
    public float currentHealth = maxHealth;

    public void IsShot(float amount)
    {
        Debug.Log("IsShot");
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Death");
        }
    }
}
