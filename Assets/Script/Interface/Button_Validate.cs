using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Photon.Pun;

public class Button_Validate : MonoBehaviour
{
    private GameObject slider0;
    private GameObject slider1;
    private GameObject slider6;
    private GameObject slider7;

    private string path = "";

    //Creates the JSON Object that will be used for storage
    JSON_Format JsonData = new JSON_Format();

    private float value_HP;
    private float value_shot_CD;
    private float value_virus_color;
    private float value_scientist_color;

    public void OnClickValidate()
    {
        //Get the HP value from the slider
        slider0 = GameObject.Find("Barre vie");
        value_HP = slider0.GetComponent<Slider>().value;
        //Get the Shot Cooldown value from the slider
        slider1 = GameObject.Find("Slider (1)");
        value_shot_CD = slider1.GetComponent<Slider>().value;
        //Get the Virus color from the slider
        slider6 = GameObject.Find("Slider (6)");
        value_virus_color = slider6.GetComponent<Slider>().value;
        //Get the Scientist color from the slider
        slider7 = GameObject.Find("Slider (7)");
        value_scientist_color = slider7.GetComponent<Slider>().value;
        
        //Defines the path to where the JSON is saved
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        //Inputs the data taken from the sliders in the JSON string
        JsonData.HP = value_HP;
        JsonData.Shot_Cooldown = value_shot_CD;
        JsonData.Scientist_Color = value_scientist_color;
        JsonData.Virus_Color = value_virus_color;

        //Creates the JSON string from the filled JSON object
        string json = JsonUtility.ToJson(JsonData);

        //Writes the JSON string in a file located at the path
        using StreamWriter writer = new StreamWriter(path);
        writer.Write(json);

        PhotonNetwork.LoadLevel("GameScene");

    }
}
