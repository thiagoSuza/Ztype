using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CreatAndJoinRooms : MonoBehaviourPunCallbacks
{

    public InputField creatIp, enterIp,nameIp;

   public void CreatRoom()
    {
        PhotonNetwork.CreateRoom(creatIp.text);
    }
   
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(enterIp.text);
    }

    public void Exit()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);

    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel(7);
    }

    public void ChangeName()
    {
        PhotonNetwork.NickName = nameIp.text;
    }
}
