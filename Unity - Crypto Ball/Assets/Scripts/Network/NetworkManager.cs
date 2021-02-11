using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] byte maxPlayers = 10;

    public static event Action OnPlayerJoined;
    public static event Action OnPlayerLeft;
    [SerializeField] GameObject canvasPrefab;

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

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        PhotonNetwork.Instantiate(canvasPrefab.name, transform.position, transform.rotation);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        OnPlayerJoined?.Invoke();
        Debug.Log("Joined!");
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        // If you are the host, transfer canvas to another player that is still in the room
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        OnPlayerJoined?.Invoke();
        Debug.Log(newPlayer.NickName + " joined the lobby!");
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        OnPlayerLeft?.Invoke();
    }
}
