using UnityEngine.UI;
using Photon.Pun;
using UnityEngine;

public class CreateJoinRoom : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

    // Creation of the game with the loading of the configuration menu
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
        PhotonNetwork.LoadLevel("InterfaceScene");
    }

    // Loading an already existing game
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    // Loading game level
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }
}
