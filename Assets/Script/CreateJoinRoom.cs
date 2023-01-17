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
/*        PhotonNetwork.LoadLevel("InterfaceScene");*/
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }
}
