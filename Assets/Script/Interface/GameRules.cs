using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//Defines utility functions for the treatment of the JSON SaveData
public class GameRules
{
    //Associates the values of the Slider Color virus to colors. If the value is not a standard one, the color is red
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
    //Associates the values of the Slider Color scientist to colors. If the value is not a standard one, the color is green
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
    //Utility function to reaf the JSON SaveData
    public string gamerules_read()
    {
        string path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();
        return (json);
    }
}


