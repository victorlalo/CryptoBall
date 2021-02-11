using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;

public class NetworkCanvas : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] Text numPlayersText;
    [SerializeField] Text helloMessage;
    public int playerCount = 0;

    //public static event Action OnSpaceBarPressed;

    void Awake()
    {
        helloMessage.gameObject.SetActive(false);
        NetworkManager.OnPlayerJoined += setNumPlayers;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activateMessage();
        }
        setNumPlayers();
    }

    public void setNumPlayers()
    {
        playerCount++;
        numPlayersText.text = "Number of Players: " + playerCount.ToString();
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
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(playerCount);
        }
        else
        {
            playerCount = (int)stream.ReceiveNext();
        }
    }
}
