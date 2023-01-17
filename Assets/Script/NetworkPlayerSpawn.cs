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

    void CreateController()
    {

        Debug.Log("Test");

        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));

        if (PlayerPrefs.GetInt(gameOption, 0) == 0)
        {
           controller = PhotonNetwork.Instantiate(VRPrefab.name, randomPosition, Quaternion.identity);
            Debug.Log("VR généré");
        }
        else if (PlayerPrefs.GetInt(gameOption, 0) == 1)
        {
            controller = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity, 0, new object[] { PV.ViewID });

            Debug.Log("3RD bejbe");
        }
    }

    public void Die()
    {
        PhotonNetwork.Destroy(controller);
        CreateController();
    }
}
