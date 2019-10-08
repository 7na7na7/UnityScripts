using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;

public class BulletScript : MonoBehaviourPunCallbacks
{
    public float speed;
    public PhotonView PV;
    private int dir;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * dir);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
            PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
        if (!PV.IsMine && other.CompareTag("Player") && other.GetComponent<PhotonView>().IsMine) //느린쪽에 맞춰 히트판정, 맞는 사람 기준으로 안억울하게
        {
            other.GetComponent<PlayerScript>().Hit();
            PV.RPC("DestroyRPC",RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    void DirRPC(int dir)
    {
        this.dir = dir;
    }

    [PunRPC]
    void DestroyRPC()
    {
        Destroy(gameObject);
    }

}
