using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public static Ball _Instance;
    public float topSpeed = 10f;
    Rigidbody rb;

    Vector3 ballOriginPosition;

    // EVENTS
    public static event Action<Team> OnGoalScored;
    public static event Action<float> OnWallHit;
    public static event Action OnPostHit;
    void Start()
    {
        if (_Instance != null){
            Destroy(this);
        }
        else{
            _Instance = this;
        }

        rb = GetComponent<Rigidbody>();
        ballOriginPosition = transform.position;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            ResetBall();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -topSpeed, topSpeed), Mathf.Clamp(rb.velocity.y, -topSpeed, topSpeed),  Mathf.Clamp(rb.velocity.z, -topSpeed, topSpeed));
    }

    public void ResetBall(){
        rb.velocity = Vector3.zero;
        transform.position = ballOriginPosition;
        //transform.position = new Vector3(UnityEngine.Random.Range(10, 50), 5, UnityEngine.Random.Range(-60, 60));
    }

    public void StopMoving(){
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Blue Goal")){
            print("GOOOOOOOOOOOOOAAAALLLAZO!");

            // trigger goal event notification
            //Team team = (transform.position.x > 0) ? Team.Red : Team.Blue;
            OnGoalScored?.Invoke(Team.Red);
            ResetBall();
            
        }
        else if (other.gameObject.CompareTag("Red Goal")){
            OnGoalScored?.Invoke(Team.Blue);
            ResetBall();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Wall")){
            float distFromGoal = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Blue Goal").transform.position);
            OnWallHit?.Invoke(distFromGoal);
        }
        else if (other.gameObject.CompareTag("Post")){
            OnPostHit?.Invoke();
        }
    }
}
