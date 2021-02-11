using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkCanvas : MonoBehaviour
{
    [SerializeField] Text numPlayersText;
    [SerializeField] Text helloMessage;

    void Start()
    {
        helloMessage.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void setNumPlayers(int players)
    {
        numPlayersText.text = "Number of Players: " + players.ToString();
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
