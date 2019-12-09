using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 애니메이션_Play : MonoBehaviour
{
    //anim.Play();는 완전 신세계이다... 
    //이거쓰면 트랜지션 그딴거 필요없다. 대신 if문으로 제한할때는 좀 해줘야 하긴 한다.
    public Animator anim;

    private void Start()
    {
        StartCoroutine(animtest());
    }
    IEnumerator animtest() 
    {
        anim.Play("run");
        yield return new WaitForSeconds(3f);
        anim.Play("walk");
        yield return new WaitForSeconds(3f);
        anim.Play("JumpAnim");
    }
    
    
    
    public Animator animator;
    private void Start()
    {
        StartCoroutine(CheckAnimationState());
    }
   
    IEnumerator CheckAnimationState() //현재 애니메이션 상태 체크
    {

        while (!animator.GetCurrentAnimatorStateInfo(0)
            .IsName("원하는 애니메이션 이름")) 
        { 
            //전환 중일 때 실행되는 부분
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0)
                   .normalizedTime < 1) //normalizedTime은 0에서 1까지의 값, 1보다 작으면 실행 중
        {
            //애니메이션 재생 중 실행되는 부분
            yield return null;
        }
	
        //애니메이션 완료 후 실행되는 부분

    }
}
