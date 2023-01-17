using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Photon.Pun;

public class Button_Validate : MonoBehaviour
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
    GameRules gamerules = new GameRules();

    public float value_HP;
    public float value_shot_CD;
    public float value_tp_CD;
    public float value_kills_victory;
    public float value_explosion;
    public float value_time_capture;
    public float value_virus_color;
    public float value_scientist_color;

    public void OnClickValidate()
    {
        slider0 = GameObject.Find("Barre vie");
        value_HP = slider0.GetComponent<Slider>().value;
        //Debug.Log(value_HP);
        //Shot Cooldown
        slider1 = GameObject.Find("Slider (1)");
        value_shot_CD = slider1.GetComponent<Slider>().value;
        //Debug.Log(value_shot_CD);
        //TP Cooldown
        slider2 = GameObject.Find("Slider (2)");
        value_tp_CD = slider2.GetComponent<Slider>().value;
        //Debug.Log(value_tp_CD);
        //Kills For Victory
        slider3 = GameObject.Find("Slider (3)");
        value_kills_victory = slider3.GetComponent<Slider>().value;
        //Debug.Log(value_kills_victory);
        //Explosions radius
        slider4 = GameObject.Find("Slider (4)");
        value_explosion = slider4.GetComponent<Slider>().value;
        //Debug.Log(value_explosion);
        //Time to capture zone
        slider5 = GameObject.Find("Slider (5)");
        value_time_capture = slider5.GetComponent<Slider>().value;
        //Debug.Log(value_time_capture);
        //Virus shot color
        slider6 = GameObject.Find("Slider (6)");
        value_virus_color = slider6.GetComponent<Slider>().value;
        //Debug.Log(value_virus_color);
        //Scientist shot color
        slider7 = GameObject.Find("Slider (7)");
        value_scientist_color = slider7.GetComponent<Slider>().value;
        //Debug.Log(value_scientist_color);

        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentpath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        JsonData.HP = value_HP;
        JsonData.Explosion_Radius = value_explosion;
        JsonData.Time_Capture = value_time_capture;
        JsonData.TP_Cooldown = value_tp_CD;
        JsonData.Shot_Cooldown = value_shot_CD;
        JsonData.Kills_Victory = value_kills_victory;
        JsonData.Scientist_Color = value_scientist_color;
        JsonData.Virus_Color = value_virus_color;

        string json = JsonUtility.ToJson(JsonData);

        using StreamWriter writer = new StreamWriter(path);
        writer.Write(json);

        PhotonNetwork.LoadLevel("GameScene");

    }
}
