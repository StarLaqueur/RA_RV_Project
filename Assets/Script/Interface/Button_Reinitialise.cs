using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Button_Reinitialise : MonoBehaviour
{
    private GameObject slider0;
    private GameObject slider1;
    private GameObject slider6;
    private GameObject slider7;

    private string path = "";

    //Creates the JSON Object that will be used for storage
    JSON_Format JsonData = new JSON_Format();

    public void OnClickReinitialise ()
    {
        //Sets the Number of HP on the slider to 10
        slider0 = GameObject.Find("Barre vie");
        slider0.GetComponent<Slider>().value = 10;
        //Sets the Shot Cooldown on the slider to 1.5
        slider1 = GameObject.Find("Slider (1)");
        slider1.GetComponent<Slider>().value = 1.5f;
        //Sets the Virus Color on the slider to Red
        slider6 = GameObject.Find("Slider (6)");
        slider6.GetComponent<Slider>().value = 1;
        //Sets the Scientist Color on the slider to Green
        slider7 = GameObject.Find("Slider (7)");
        slider7.GetComponent<Slider>().value = 1;

        //Defines the path to where the JSON is saved
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";


        //Inputs the default data in the JSON string
        JsonData.HP = 10;
        JsonData.Shot_Cooldown = 1.5f;
        JsonData.Scientist_Color = 1;
        JsonData.Virus_Color = 1;

        //Creates the JSON string from the filled JSON object
        string json = JsonUtility.ToJson(JsonData);

        //Writes the JSON string in a file located at the path
        using StreamWriter writer = new StreamWriter(path);
        writer.Write(json);
    }
}
