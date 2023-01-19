using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameRules
{
    /*public float HP = 10;
    public float Explosion_Radius = 5;
    public float TP_Cooldown = 3;
    public float Kills_Victory = 10;
    public float Shot_Cooldown = 1.5f;
    public float Time_Capture = 30;
    public float Virus_Color = 1;
    public float Scientist_Color = 1;*/

    public Color GetColorVirus(float colorChoiceVirus)
    {
        switch (colorChoiceVirus)
        {
            case 1f: return Color.red;
            case 2f: return Color.yellow;
            case 3f: return Color.cyan;
        }

        return Color.red;
    }

    public Color GetColorScientist(float colorChoiceScientist)
    {
        switch (colorChoiceScientist)
        {
            case 1f: return Color.green;
            case 2f: return Color.blue;
            case 3f: return Color.white;
        }
        return Color.green;
    }
    public string gamerules_read()
    {
        string path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();
        //Debug.Log(json);
        return (json);
    }

}


