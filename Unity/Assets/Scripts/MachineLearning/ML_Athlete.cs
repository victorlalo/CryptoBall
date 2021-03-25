using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ML_Athlete : MonoBehaviour
{
    // ATTRIBUTES
    public string player_name;
    public Team team;
    public float speed = 1f;
    public float stamina = 1f;
    public float power = 1f;
    public float aggression = 1f;
    public float showmanship = 1f;
    public float intellect = 1f;
    public float leadership = 1f;

    public float age = 21f;
    public float experience = 0f;

    public Rigidbody rb;
    public Vector3 targetGoal;
    public Vector3 ownGoal;

    Vector3 kickForce;
    public bool isTrackingBall = true;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (team == Team.Red){
            targetGoal = GameObject.FindGameObjectWithTag("Blue Goal").transform.position;
            ownGoal = GameObject.FindGameObjectWithTag("Red Goal").transform.position;
        }
        else{
            targetGoal = GameObject.FindGameObjectWithTag("Red Goal").transform.position;
            ownGoal = GameObject.FindGameObjectWithTag("Blue Goal").transform.position;
        }
    }

    protected virtual void Update()
    {
        Vector3 playerRot = transform.eulerAngles;
        transform.LookAt(Ball._Instance.transform);
        playerRot.y = transform.eulerAngles.y;
        transform.eulerAngles = playerRot;
    }

    protected virtual void FixedUpdate() {
        if (!isTrackingBall){
            return;
        }
        Vector3 nextPos = rb.position;
        nextPos = Vector3.MoveTowards(rb.position, Ball._Instance.transform.position, speed * Time.fixedDeltaTime);
        nextPos.y = rb.position.y;
        rb.position = nextPos;
        
    }

    
}
