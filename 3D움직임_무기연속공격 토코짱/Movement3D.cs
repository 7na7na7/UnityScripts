using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    public float Speed;
    public float gravity = -1f;
    private float moveSpeed;
    private Vector3 moveDirection;
    private CharacterController characterController;
    public float jumpForce = 5f;

    public void SetMoveSpeed(float v)
    {
        Speed = moveSpeed * v;
    }
        
    private void Awake()
    {
        moveSpeed = Speed;
        characterController = GetComponent<CharacterController>();
    }

    public bool isGround()
    {
        return characterController.isGrounded;
    }
    void Update()
    {
        //중력 설정, 플레이어가 땅을 밟고 있지 않다면
        //y축 이동방향에 gravity를 더해준다.
        if (!characterController.isGrounded)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }
        //이동, 설정, CharacterController의 Move()함수를 이용한 이동
        characterController.Move(moveDirection * Speed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection=new Vector3(direction.x,moveDirection.y,direction.z);
    }

    public void JumpTo()
    {
        //캐릭터가 땅을 밟고 있으면 점프
        moveDirection.y = jumpForce;
    }
}
