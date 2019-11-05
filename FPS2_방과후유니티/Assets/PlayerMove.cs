using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //키를 입력하여 플레이어를 움직인다
    float h, v,speed=10;
    //캐릭터 컨트롤러를 이용해 움직이겠다
    CharacterController cc;
    //캐릭터를 점프하겠다
    //1. 중력
    public float gravity = -9.81f;
    //2. 점프파워
    public float jumpPower = 5.0f;
    //3. 벨로시티
    float yVelocity;
    //최대점프횟수
    public int maxJump=2;
    //점프카운트
    int jumpCnt;
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //-1~1 숫자입력
        h= Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //Vector3 dir= Vector3.right*h+Vector3.up * v;
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        //카메라가 보는 방향을 앞방향으로 정하겠다
        dir=Camera.main.transform.TransformDirection(dir);
        if (cc.isGrounded)
        {
            jumpCnt = 0;
            yVelocity = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCnt<maxJump)
        {
            yVelocity = jumpPower;
            jumpCnt++; 
        }
         yVelocity += gravity * Time.deltaTime;

        dir.y = yVelocity;
        cc.Move(dir * speed * Time.deltaTime);
        //transform.position += dir * speed * Time.deltaTime;

        
    }
}
