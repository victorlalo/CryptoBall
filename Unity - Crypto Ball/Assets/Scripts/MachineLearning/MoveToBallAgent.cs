using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToBallAgent : Agent
{
    [SerializeField] GameObject ball;
    Vector3 playerStartPos;
    Vector3 ballStartPos;
    [SerializeField] float moveSpeed = 10;
    private void Start() {
        //ball = FindObjectOfType<Ball>().gameObject;

        playerStartPos = transform.position;
        ballStartPos = ball.transform.position;

    }

    public override void OnEpisodeBegin()
    {
        transform.position = playerStartPos;
        ball.transform.position = ballStartPos;
    }

    
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(ball.transform.position);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        transform.position += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ball")){
            SetReward(1f);
            Debug.Log("WIN!");
            EndEpisode();
        }
        if (other.gameObject.CompareTag("Wall")){
            SetReward(-1f);
            EndEpisode();
        }
    }
}
