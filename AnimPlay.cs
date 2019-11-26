using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlay : MonoBehaviour
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
}
