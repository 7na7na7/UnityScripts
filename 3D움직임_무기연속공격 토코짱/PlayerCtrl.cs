using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Transform cameraTransform;
    private Movement3D movement3D;
    private PlayerAnimator playerAnimator;
   
    private void Awake()
    {
        Cursor.visible = false; //커서 보이지 않게
        Cursor.lockState = CursorLockMode.Locked; //커서위치 고정

        movement3D = GetComponent<Movement3D>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    void Update()
    {
        //방향키로 이동
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        playerAnimator.OnMovement(x,z); //애니메이터 설정
        
        
        if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Movement") || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (movement3D.isGround())
                {
                    playerAnimator.JumpPlay();
                    //playerAnimator.OnJump();
                    movement3D.JumpTo();   
                }
            }
        }
        else
        {
            x = 0;
            z = 0;
        }


        if (z >= 0) //앞이동
        {
            if(x==0) 
                movement3D.SetMoveSpeed(1f);
            else
                movement3D.SetMoveSpeed(0.7f);
        }
        else
        {
            if(x==0) 
                movement3D.SetMoveSpeed(0.7f);
            else
                movement3D.SetMoveSpeed(0.55f);
        }

        movement3D.MoveTo(cameraTransform.rotation.normalized * new Vector3(x, 0, z));
        
        if (Input.GetMouseButtonDown(0))
        {
            if (movement3D.isGround())
            {
                playerAnimator.ResetJumpTrigger();
                playerAnimator.OnSwordAttack();
            }
        }
    }
    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = cameraTransform.position.x;
        pos.z = cameraTransform.position.z;
        transform.LookAt(pos);
        transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y+160,transform.eulerAngles.z);
    }
}
