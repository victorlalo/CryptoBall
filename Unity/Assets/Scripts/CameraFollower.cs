using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Vector3 camOffset;
    public float smoothness = 0.1f;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Ball._Instance.transform.position + camOffset, smoothness * Time.fixedDeltaTime);
    }
}
