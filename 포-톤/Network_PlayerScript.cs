using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.XR;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Network_PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    private bool candash = true;
    public float dashtime;
    public float jumpforce;
    public float speed;
    public Rigidbody2D RB;
    public Animator AN;
    public SpriteRenderer SR;
    public PhotonView PV;
    public Text NickNameText;
    public Image HealthImage;

    private bool isGround;
    private Vector3 curPos;

    private void Awake()
    {
        //닉네임
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
        NickNameText.color = PV.IsMine ? Color.green : Color.red;
        if (PV.IsMine)
        {
            //2D카메라
            var CM = GameObject.Find("CMCamera").GetComponent<CinemachineVirtualCamera>();
            CM.Follow = transform;
            CM.LookAt = transform;
        }
    }
    
    private void Update()
    {
        if (PV.IsMine)
        {
            //이동
            float axis = Input.GetAxisRaw("Horizontal");
            RB.velocity=new Vector2(speed*axis,RB.velocity.y);

            if (axis != 0)
            {
                AN.SetBool("walk",true);
                PV.RPC("FlipXRPC",RpcTarget.AllBuffered,axis); //재접속시 flix를 동기화해주기 위해 AllBuffered
            }
            else
                AN.SetBool("walk",false);
            
            // ↑ 점프, 바닥체크
            isGround = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -0.5f), 0.07f, 1 << LayerMask.NameToLayer("Ground"));
            AN.SetBool("jump", !isGround);
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGround) 
                PV.RPC("JumpRPC", RpcTarget.All);

            //총알 발사
            if (Input.GetKeyDown(KeyCode.X)||Input.GetKeyDown(KeyCode.Less))
            {
                PhotonNetwork.Instantiate("Bullet",
                    transform.position + new Vector3(SR.flipX ? -0.4f : 0.4f, -0.11f, 0), Quaternion.identity)
                    .GetComponent<PhotonView>().RPC("DirRPC",RpcTarget.All,SR.flipX ? -1 : 1);
                AN.SetTrigger("shot");
            }
            //대쉬
            {
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Greater))
                {
                    StartCoroutine(dash());
                }
            }
        }
        //IsMine이 아닌 것들은 부드럽게 위치 동기화
        else if ((transform.position - curPos).sqrMagnitude >= 100)
            transform.position = curPos;
        else
            transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 10);
    }

    public void Hit()
    {
        HealthImage.fillAmount -= 0.1f;
        if (HealthImage.fillAmount <= 0)
        {
            GameObject.Find("Canvas").transform.Find("RespawnPanel").gameObject.SetActive(true);
            PV.RPC("DestroyRPC",RpcTarget.AllBuffered); //AllBuffered로 해야한다
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("fall"))
        {
            /*
            GameObject.Find("Canvas").transform.Find("RespawnPanel").gameObject.SetActive(true);
                PV.RPC("DestroyRPC", RpcTarget.AllBuffered); //AllBuffered로 해야한다
                */
            }
    }

    [PunRPC]
    void DestroyRPC()
    {
        Destroy(gameObject);
    }
    [PunRPC]
    void FlipXRPC(float axis)
    {
        SR.flipX = axis == -1; //flipx를 반대로
    }
    
    [PunRPC]
    void JumpRPC()
    {
        RB.velocity = Vector2.zero;
        RB.AddForce(Vector2.up * jumpforce);
    }

    IEnumerator dash()
    {
        if (candash)
        {
            candash = false;
            RB.velocity = new Vector2(0, 3);
            speed *= 4;
            yield return new WaitForSeconds(dashtime);
            speed /= 4;
            yield return new WaitForSeconds(2f);
            candash = true;
        }
        else
        {
            yield return null;
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //여기서 변수 동기화가 진행됨
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(HealthImage.fillAmount);
        }
        else
        {
            curPos = (Vector3) stream.ReceiveNext();
            HealthImage.fillAmount = (float) stream.ReceiveNext();
        }
    }
    
}
