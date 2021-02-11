using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMove : MonoBehaviourPun//, IPunObservable
{
    float speed = 8f;
    //Rigidbody rb;
    Vector3 position;

    public static Color[] playerColors =
    {
        Color.red,
        Color.blue,
        Color.yellow,
        Color.green,
        Color.white,
        Color.black
    };

    //PhotonView photonView;
    //[SerializeField] MonoBehaviour[] scriptsToIgnore;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        Debug.Log(photonView.OwnerActorNr);
        GetComponentInChildren<MeshRenderer>().material.color = playerColors[photonView.OwnerActorNr - 1];

        //photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        transform.position = transform.position + new Vector3(horiz, vert) * Time.fixedDeltaTime * speed;
    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        stream.SendNext(rb.position);
    //    }
    //    else
    //    {
    //        position = (Vector3)stream.ReceiveNext();
    //    }
    //}
}
