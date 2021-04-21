using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    private Animator animator;
    private Color originColor;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        //피격 애니메이션 재생
        animator.SetTrigger("onHit");
    }
}
