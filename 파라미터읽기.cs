using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 파라미터읽기 : MonoBehaviour
{
    Animator animator;
    if (animator.GetBool("isdown") ==false)
    {
        animator.speed/=2; // animator.speed를 사용하면 애니메이션 재생속도 조절 가능!
    }
    //이런식으로 GetBool을 이용하여 파라미터 값을 얻어올 수 있다.
}



