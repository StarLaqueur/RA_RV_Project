using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;
using System.Collections;
using UnityEngine;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI textMesh;

    // Startup function to use Photon configurations
    private void Start()
    {
        StartCoroutine(Loading());
        PhotonNetwork.ConnectUsingSettings();
    }

    // Connection of the loading menu to the lobby
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    // Loading lobby scene
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    // Loading text animation
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