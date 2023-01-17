using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawn : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    public GameObject VRPrefab;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    const string gameOption = "gameSetup";
    // Start is called before the first frame update

    /*public string json_gamerules;
    public JSON_Format object_gamerules;
    public GameRules gamerules = new GameRules();*/

    PhotonView PV;

    GameObject controller;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        //json_gamerules = gamerules.gamerules_read();
        //object_gamerules = JsonUtility.FromJson<JSON_Format>(json_gamerules);
    }

    void Start()
    {
        CreateController();
    }

    void CreateController()
    {

        //Debug.Log("Test");

        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));

        if (PlayerPrefs.GetInt(gameOption, 0) == 0)
        {
           controller = PhotonNetwork.Instantiate(VRPrefab.name, randomPosition, Quaternion.identity, 0, new object[] { PV.ViewID });
            //Debug.Log("VR généré");
        }
        else if (PlayerPrefs.GetInt(gameOption, 0) == 1)
        {
            controller = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity, 0, new object[] { PV.ViewID });

            //Debug.Log("3RD bejbe");
        }
    }

    public void Die()
    {
        PhotonNetwork.Destroy(controller);
        CreateController();
    }
}
