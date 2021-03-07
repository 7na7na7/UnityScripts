using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 애니메이션끝확인 : MonoBehaviour
{
    public Animator anim;
    bool isEndAnim()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f;
    }
}
