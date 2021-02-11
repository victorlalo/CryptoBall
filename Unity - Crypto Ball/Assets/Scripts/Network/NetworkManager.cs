using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] byte maxPlayers = 10;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected to Server!");

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("CryptoBallNetwork", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined!");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined the lobby!");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
