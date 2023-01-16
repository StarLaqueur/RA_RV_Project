using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    public GameObject VRPrefab;

    const string gameOption = "gameSetup";
    public GameManagement game;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.PlayerList.Length <= 1)
        {
            game.SetPinPoint();
        }
     
        if (PlayerPrefs.GetInt(gameOption, 0) == 0)
        {
            PhotonNetwork.Instantiate(VRPrefab.name, game.SetSpawnPoint(), Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt(gameOption, 0) == 1)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, game.SetSpawnPoint(), Quaternion.identity);
        }
    }
}
