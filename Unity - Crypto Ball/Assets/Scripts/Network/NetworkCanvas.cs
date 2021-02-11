using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NetworkCanvas : MonoBehaviour
{
    [SerializeField] Text numPlayersText;
    [SerializeField] Text helloMessage;
    int playerCount = 0;

    public static event Action OnSpaceBarPressed;

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
}
