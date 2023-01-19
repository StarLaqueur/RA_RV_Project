using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.XR;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NetworkPlayerSpawn : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    public GameObject VRPrefab;
    public JSON_Format object_gamerules;
    public GameRules gamerules = new GameRules();
    public string json_gamerules;
    public float number_kills;
    public float master_number_kills;


    const string gameOption = "gameSetup";
    public GameManagement game;

    PhotonView PV;

    GameObject controller;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            json_gamerules = gamerules.gamerules_read();
            object_gamerules = JsonUtility.FromJson<JSON_Format>(json_gamerules);
            master_number_kills = object_gamerules.Kills_Victory;
            number_kills = master_number_kills;
            ReadNumberKills(master_number_kills);

        }
        CreateController();
    }

    public void CreateController()
    {
        game.SetPinPoint();
        Debug.Log("test Respawn");
        if (PlayerPrefs.GetInt(gameOption, 0) == 0)
        {
            controller = PhotonNetwork.Instantiate(VRPrefab.name, game.SetSpawnPoint(), Quaternion.identity, 0, new object[] { PV.ViewID });
        }
        else if (PlayerPrefs.GetInt(gameOption, 0) == 1)
        {
            controller = PhotonNetwork.Instantiate(playerPrefab.name, game.SetSpawnPoint(), Quaternion.identity, 0, new object[] { PV.ViewID });
        }
    }

    public void Die()
    {
        game.Respawn(controller);
    }

    void ReadNumberKills(float kills)
    {
    PV.RPC("RPC_ReadNumberKills", RpcTarget.AllBuffered, kills);
    }
    [PunRPC]
    void RPC_ReadNumberKills(float kills_for_victory)
    {
    number_kills = kills_for_victory;
    }

}
