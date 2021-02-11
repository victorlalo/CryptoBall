using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;
using Photon.Realtime;

public class NetworkCanvas : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] Text numPlayersText;
    [SerializeField] Text helloMessage;
    public int playerCount = 0;

    public bool helloMessageActive = false;

    //public static event Action OnSpaceBarPressed;

    void Awake()
    {
        helloMessage.gameObject.SetActive(false);
        //NetworkManager.OnPlayerJoined += AddPlayer;
        //NetworkManager.OnPlayerLeft += SubtractPlayer;
    }

    private void Start()
    {
        setNumPlayers();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            helloMessageActive = true;
            StartCoroutine(DeactivateMessage());
        }
    }

    public void setNumPlayers()
    {
        //numPlayersText.text = "Number of Players: " + playerCount.ToString();
        playerCount = PhotonNetwork.PlayerList.Length;
        numPlayersText.text = "Number of Players: " + playerCount;
    }

    public void activateMessage()
    {
        StopCoroutine(DeactivateMessage());
        helloMessage.gameObject.SetActive(true);
        StartCoroutine(DeactivateMessage());
    }

    IEnumerator DeactivateMessage()
    {
        yield return new WaitForSeconds(2f);
        helloMessage.gameObject.SetActive(false);
        helloMessageActive = false;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(helloMessageActive);
        }
        else
        {
            helloMessageActive = (bool)stream.ReceiveNext();
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //playerCount++;
        setNumPlayers();
    }
    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        //playerCount--;
        setNumPlayers();
    }
}
