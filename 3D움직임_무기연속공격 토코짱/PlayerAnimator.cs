using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    public GameObject AttackCollision;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnMovement(float horizontal, float vertical)
    { 
        animator.SetFloat("Horizontal",horizontal); 
        animator.SetFloat("Vertical",vertical);
    }

    public void JumpPlay()
    {
        animator.Play("Jump");
    }
    public void OnJump()
    {
        animator.SetTrigger("onJump");
    }

    public void OnAttackCollision()
    {
        AttackCollision.SetActive(true);
    }
    public void OnSwordAttack()
    {
        animator.SetTrigger("onSwordAttack");
    }

    public void ResetJumpTrigger()
    {
        animator.ResetTrigger("onJump");
    }
}
