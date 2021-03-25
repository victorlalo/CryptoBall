using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : Athlete
{
    protected override void Start()
    {
        base.Start();
    }



    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector3 nextPos = rb.position;
        nextPos = Vector3.MoveTowards(rb.position, Ball._Instance.transform.position, speed * Time.fixedDeltaTime);
        nextPos.y = rb.position.y;
        rb.position = nextPos;
    }


    // if team mate close to ball, find an opening for a pass. Position self at optimal shooting location (no targets in the way, goalie is opposite)
    // If close to ball, and no opening, cross to open team mate
    // Decide to use sprint (consumes stamina)
    // If ball in back half, shoot towards the middle
    // If ball in front half, shoot towards goal
}
