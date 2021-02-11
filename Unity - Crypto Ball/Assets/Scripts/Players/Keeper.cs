using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keeper : Athlete
{
    Vector2 boundingRadius = new Vector2(25f, 25f);
    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector3 nextPos = rb.position;
        nextPos = Vector3.MoveTowards(rb.position, Ball._Instance.transform.position, speed * Time.fixedDeltaTime);
        // nextPos.y = rb.position.y;

        nextPos.x = (team == Team.Red) ? Mathf.Clamp(nextPos.x, ownGoal.x + 7f, ownGoal.x + boundingRadius.x) : Mathf.Clamp(nextPos.x, ownGoal.x - boundingRadius.x, ownGoal.x - 7f);
        nextPos.z = Mathf.Clamp(nextPos.z, ownGoal.z - boundingRadius.y, ownGoal.z + boundingRadius.y);

        // average pos between ball and goal
        //nextPos = (nextPos + ownGoal)/2f;
        nextPos.y = rb.position.y;
        rb.position = nextPos;
    }

    // If ball makes contact, find closest OPEN defender and pass forward to him
        // If no open defenders, punt the ball to midfield
    // Track VELOCITY and DIRECTION of the ball and follow, but stay within confines of the bounding box
    // If ball inside of bounding box, go to it and get it out

    // If ball moving towards goal and out of reach, use dive to attempt to reach it (if you have enough stamina)
}
