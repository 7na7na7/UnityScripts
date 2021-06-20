using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnimationState : MonoBehaviour
{
    void Update()
    {
        if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            print("현재 애니메이션 스테이트는 Idle입니다!");
        }
    }
}
