using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    int[] score = {0,0};
    [SerializeField] Text scoreText;

    void Start()
    {
        Ball.OnGoalScored += ScoreGoal;
        scoreText.text = "0 - 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScoreGoal(Team team){
        // pause gameplay
        // Goal celebration! 
        // -> "GOAL!" Message
        // -> Screen Shake and fireworks
        // -> player dancing
        // reset player positions

        // update score
        score[(int)team]++;
        scoreText.text = score[0].ToString() + " - " + score[1].ToString();
    }
}
