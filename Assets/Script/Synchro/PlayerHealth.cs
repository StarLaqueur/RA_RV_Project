using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public const float maxHealth = 10;
    public float currentHealth = maxHealth;

    // Updating hitpoints when firing
    public void IsShot(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

}
