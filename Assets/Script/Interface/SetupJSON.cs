using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Defines the structure of the SaveData JSON to save the game preferences defined by the host 
public class SetupJSON : MonoBehaviour
{

    void Start ()
    {
    }
}
public class JSON_Format
{
    public float HP; //Save the player health
    public float Shot_Cooldown; //Save the time between each shot
    public float Virus_Color; //Save the color of the Viruses's shots
    public float Scientist_Color; //Save the color of the Scientists's shots
}

