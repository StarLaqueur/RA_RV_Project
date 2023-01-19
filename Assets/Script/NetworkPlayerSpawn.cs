using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawn : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    public GameObject VRPrefab;

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
}
