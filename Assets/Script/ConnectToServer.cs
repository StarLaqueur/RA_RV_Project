using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;
using System.Collections;
using UnityEngine;

public class ConnectToServer : MonoBehaviourPunCallbacks
{

    public TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Loading());
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    private IEnumerator Loading()
    {
        while (true)
        {
            textMesh.ForceMeshUpdate();
            textMesh.text = "Chargement";
            yield return new WaitForSeconds(0.5f);
            textMesh.text = "Chargement.";
            yield return new WaitForSeconds(0.5f);
            textMesh.text = "Chargement..";
            yield return new WaitForSeconds(0.5f);
            textMesh.text = "Chargement...";
            yield return new WaitForSeconds(0.5f);
        }
    }
}