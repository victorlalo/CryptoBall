using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time;
    public float gameDuration;
    public float GameTime{get; private set;}
    Text timerText;
    string minutes, seconds;

    void Start()
    {
        GameTime = 0f;
        timerText = GetComponentInChildren<Text>();
        timerText.text = "00:00";
    }

    void Update()
    {
        GameTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(GameTime / 60f).ToString();
        if (minutes.Length == 1){
            minutes = "0" + minutes;
        }
        seconds = Mathf.FloorToInt(GameTime % 60f).ToString();
        if (seconds.Length == 1){
            seconds = "0" + seconds;
        }


        timerText.text = minutes.ToString() + ":" + seconds.ToString();
    }
}
