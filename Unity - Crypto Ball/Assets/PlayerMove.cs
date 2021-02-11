using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviour, IPunObservable
{
    float speed = 10f;
    Rigidbody rb;

    PhotonView photonView;
    //[SerializeField] MonoBehaviour[] scriptsToIgnore;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);

        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            float horiz = Input.GetAxisRaw("Horizontal");
            float vert = Input.GetAxisRaw("Vertical");

            rb.MovePosition(rb.position + new Vector3(horiz, vert) * Time.fixedDeltaTime * speed);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rb.position);
        }
        else
        {
            rb.position = (Vector3)stream.ReceiveNext();
        }
    }
}
