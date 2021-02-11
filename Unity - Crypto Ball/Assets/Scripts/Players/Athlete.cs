using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Position{
    Keeper, Defender, Midfield, Forward, Stiker
}
public enum Team{
    Red, Blue
}

public class Athlete : MonoBehaviour
{
    // ATTRIBUTES
    public string player_name;
    public Team team;
    public float speed = 1f;
    //public float stamina = 1f;
    public float accuracy = 1f;
    public float power = 1f;
    //public float aggression = 1f;
    //public float showmanship = 1f;
    //public float intellect = 1f;
    //public float leadership = 1f;

    //public float age = 21f;
    //public float experience = 0f;

    protected Rigidbody rb;
    protected Vector3 targetGoal;
    protected Vector3 ownGoal;

    Vector3 originalPos;
    protected Vector3 kickForce;


    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPos = transform.position;

        // Set the goal to aim for
        if (team == Team.Red){
            targetGoal = GameObject.FindGameObjectWithTag("Blue Goal").transform.position;
            ownGoal = GameObject.FindGameObjectWithTag("Red Goal").transform.position;
        }
        else{
            targetGoal = GameObject.FindGameObjectWithTag("Red Goal").transform.position;
            ownGoal = GameObject.FindGameObjectWithTag("Blue Goal").transform.position;
        }

        Ball.OnGoalScored += ResetPosition;
    }

    protected void ResetPosition(Team team){
        transform.position = originalPos;
    }

    protected virtual void Update()
    {
        Vector3 playerRot = transform.eulerAngles;
        transform.LookAt(Ball._Instance.transform);
        playerRot.y = transform.eulerAngles.y;
        transform.eulerAngles = playerRot;
    }

    protected virtual void FixedUpdate() {
        
    }

    // STAMINA DRAIN FUNCTION
    // Immediate drain on sprint use. Only allow sprint boost if stamina available
    // Recover when turbo not in use
    // Gradual drain over course of match (faster drain the more sprint is used)

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ball")){
            other.gameObject.GetComponent<Ball>().StopMoving();
            kickForce = targetGoal - other.transform.position;
            //kickForce.Normalize();
            //kickForce.y *= targetGoal.y - other.transform.position.y;
            

            //Vector3 accuracyVect = new Vector3(Random.Range(1-accuracy, 1), Random.Range(1-accuracy, 1), Random.Range(1-accuracy, 1));
            // kickForce = Vector3.Scale(kickForce, accuracyVect) * power;
            kickForce = (kickForce * accuracy) * power;
            //kickForce.y = 1f;
            Debug.DrawRay(transform.position, kickForce, Color.red, 1f);

            other.gameObject.GetComponent<Rigidbody>().AddForce(kickForce, ForceMode.Impulse);
        }
    }

    
}
