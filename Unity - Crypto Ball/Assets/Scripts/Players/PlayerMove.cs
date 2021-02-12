using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMove : MonoBehaviourPun//, IPunObservable
{
    float speed = 8f;
    Rigidbody rb;
    Vector3 position;

    MeshRenderer meshR;
    bool glowing;
    Color origColor;
    Color glowColor;

    public static Color[] playerColors =
    {
        Color.red,
        Color.blue,
        Color.yellow,
        Color.green,
        Color.white,
        Color.black
    };

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(photonView.OwnerActorNr);
        meshR = GetComponentInChildren<MeshRenderer>();
        meshR.material.color = playerColors[photonView.OwnerActorNr - 1];

        origColor = meshR.material.color;
        glowColor = origColor + new Color(.75f, .75f, .75f, 1);

        //photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            this.enabled = false;
        }
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space) && !glowing)
        {
            photonView.RPC("PlayerGlowOn", RpcTarget.AllBuffered);
            glowing = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && glowing)
        {
            photonView.RPC("PlayerGlowOff", RpcTarget.AllBuffered);
            glowing = false;
        }
    }

    [PunRPC]
    public void PlayerGlowOn()
    {
        meshR.material.color = glowColor;
    }

    [PunRPC]
    public void PlayerGlowOff()
    {
        meshR.material.color = origColor;
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

        rb.MovePosition(transform.position + new Vector3(horiz, vert) * Time.fixedDeltaTime * speed);
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
