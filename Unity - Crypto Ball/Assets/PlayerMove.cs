using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviour
{
    float speed = 10f;
    Rigidbody rb;

    PhotonView photonView;
    [SerializeField] MonoBehaviour[] scriptsToIgnore;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);

        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            foreach(var script in scriptsToIgnore)
            {
                script.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + new Vector3(horiz, vert) * Time.fixedDeltaTime * speed );

    }
}
