using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class ScoreGoalAgent : Agent
{
    GameObject ball;
    Vector3 ballOriginPos;
    ML_Athlete athlete;
    Rigidbody rb;
    Vector3 moveDir = Vector3.zero;
    Vector3 kickDir = Vector3.zero;
    //Vector3 kickPower = Vector3.zero;
    //Vector3 kickScaler = new Vector3(75, 20, 32);

    bool isTrackingBall = true;

    void Start()
    {
        Ball.OnGoalScored += RewardForGoal;
        Ball.OnWallHit += PenaltyForMiss;
        Ball.OnPostHit += RewardForPost;

        ball = GameObject.FindGameObjectWithTag("Ball");
        ballOriginPos = ball.transform.position;

        athlete = GetComponent<ML_Athlete>();
    }

    public override void OnEpisodeBegin()
    {
        athlete.isTrackingBall = true;
        transform.localPosition = new Vector3(Random.Range(0, 80), 3, Random.Range(-75, 75));
        Ball._Instance.ResetBall();
        //ball.transform.position = new Vector3(Random.Range(75, 100), 5, Random.Range(-65, 65));
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //sensor.AddObservation(transform.position);
        sensor.AddObservation(ball.transform.position);
        sensor.AddObservation(athlete.targetGoal);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        kickDir.x = actions.ContinuousActions[0];
        //kickDir.y = actions.ContinuousActions[1];
        kickDir.z = actions.ContinuousActions[1];

        // kickPower.x = actions.ContinuousActions[3];
        // kickPower.y = actions.ContinuousActions[4];
        // kickPower.z = actions.ContinuousActions[5];

        // moveDir.x = actions.ContinuousActions[3];
        // moveDir.z = actions.ContinuousActions[4];

        //transform.position += (moveDir * Time.deltaTime * athlete.speed);
        // athlete.rb.MovePosition(moveDir * Time.deltaTime * athlete.speed);
    }

    // REWARDS
    void RewardForGoal(Team team){
        // if goal hit, reward with +1
        SetReward(1f);
        EndEpisode();
    }
    
    void RewardForPost(){
        SetReward(.2f);
        EndEpisode();
    }

    void PenaltyForMiss(float distFromGoal){
        SetReward(-distFromGoal/150f);
        Debug.Log(-distFromGoal/150f);
        // if missed within small distance, give small reward
        // if (distFromGoal < 10f){
        //     SetReward(0f);
        // }
        // // if missed by a long shot, give penalty relative to distance
        // else{
           
        // }
        //Debug.Log("WALL HIT!\nDISTANCE FROM GOAL: " + distFromGoal.ToString());

        EndEpisode(); 
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ball")){
            //SetReward(0.5f);
            Vector3 kickForce = kickDir * athlete.power;
            Debug.Log(kickForce);

            other.gameObject.GetComponent<Rigidbody>().AddForce(kickForce, ForceMode.Impulse);
            athlete.isTrackingBall = false;
        }

        else if (other.gameObject.CompareTag("Wall")){
            SetReward(-1f);
            EndEpisode();
        }
    }
}
