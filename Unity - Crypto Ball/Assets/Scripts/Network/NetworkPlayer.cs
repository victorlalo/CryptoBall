using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    private GameObject spawnedPlayer;

    //public int playerIndex

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawnedPlayer = PhotonNetwork.Instantiate(playerPrefab.name, transform.position + new Vector3(Random.Range(-7, 7), Random.Range(-4,4)), transform.rotation);
        
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayer);
    }
}
