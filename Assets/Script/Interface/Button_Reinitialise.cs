using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Button_Reinitialise : MonoBehaviour
{
    public GameObject slider0;
    public GameObject slider1;
    public GameObject slider2;
    public GameObject slider3;
    public GameObject slider4;
    public GameObject slider5;
    public GameObject slider6;
    public GameObject slider7;

    private string path = "";
    private string persistentpath = "";

    JSON_Format JsonData = new JSON_Format();

    public void OnClickReinitialise ()
    {
        //Number of HP
        slider0 = GameObject.Find("Barre vie");
        slider0.GetComponent<Slider>().value = 10;
        //Shot Cooldown
        slider1 = GameObject.Find("Slider (1)");
        slider1.GetComponent<Slider>().value = 1.5f;
        //TP Cooldown
        slider2 = GameObject.Find("Slider (2)");
        slider2.GetComponent<Slider>().value=3;
        //Kills For Victory
        slider3 = GameObject.Find("Slider (3)");
        slider3.GetComponent<Slider>().value = 10;
        //Explosions radius
        slider4 = GameObject.Find("Slider (4)");
        slider4.GetComponent<Slider>().value = 5;
        //Time to capture zone
        slider5 = GameObject.Find("Slider (5)");
        slider5.GetComponent<Slider>().value = 30;
        //Virus shot color
        slider6 = GameObject.Find("Slider (6)");
        slider6.GetComponent<Slider>().value = 1;
        //Scientist shot color
        slider7 = GameObject.Find("Slider (7)");
        slider7.GetComponent<Slider>().value = 1;

        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentpath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        JsonData.HP = 10;
        JsonData.Explosion_Radius = 5;
        JsonData.Time_Capture = 30;
        JsonData.TP_Cooldown = 3;
        JsonData.Shot_Cooldown = 1.5f;
        JsonData.Kills_Victory = 10;
        JsonData.Scientist_Color = 1;
        JsonData.Virus_Color = 1;

        string json = JsonUtility.ToJson(JsonData);

        using StreamWriter writer = new StreamWriter(path);
        writer.Write(json);
    }
}
