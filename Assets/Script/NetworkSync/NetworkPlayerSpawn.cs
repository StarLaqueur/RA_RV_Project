using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawn : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public GameObject VRPrefab;

    const string gameOption = "gameSetup";
    public GameManagement game;

    PhotonView PV;

    GameObject controller;

    // Player sight recovery
    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    // Player creation on startup
    void Start()
    {
        CreateController();
    }

    // Method for the creation of the player according to his choice of the drop-down menu in the lobby
    // Defining spawn points and instantiating the player with are good prefab
    public void CreateController()
    {
		game.SetPinPoint();
        if (PlayerPrefs.GetInt(gameOption, 0) == 0)
        {
           controller = PhotonNetwork.Instantiate(VRPrefab.name, game.SetSpawnPoint(), Quaternion.identity, 0, new object[] { PV.ViewID });
        }
        else if (PlayerPrefs.GetInt(gameOption, 0) == 1)
        {
            controller = PhotonNetwork.Instantiate(playerPrefab.name, game.SetSpawnPoint(), Quaternion.identity, 0, new object[] { PV.ViewID });
        }
    }

    // Death method that calls the respawn function
    public void Die()
    {
        game.Respawn(controller);
    }
}
