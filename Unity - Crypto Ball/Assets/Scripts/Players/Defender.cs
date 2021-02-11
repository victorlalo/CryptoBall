using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : Athlete
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

    // If ball makes contact, search for OPEN forward teammate, and pass ball to him
        // If no forwards open, pass ball above midfield
    // Hover around starting point, and go towards ball if within range
    // If ball past critical line, fall back and defend goal
}
