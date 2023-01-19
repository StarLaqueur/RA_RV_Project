using UnityEngine.UI;
using Photon.Pun;
using UnityEngine;

public class CreateJoinRoom : MonoBehaviourPunCallbacks
{

    public InputField createInput;
    public InputField joinInput;


    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
        PhotonNetwork.LoadLevel("InterfaceScene");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
        Debug.Log("testjoin");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("test_joined");
        PhotonNetwork.LoadLevel("GameScene");
    }
}
