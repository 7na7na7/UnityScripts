using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 콜라이더끄기 : MonoBehaviour
{
    public Collider2D col;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.space))//스페이스바 누를시
        {
            //점프
            col.enabled = false; //점프할때 콜라이더 무시
            //그리고 플레이어 발쪽에 콜라이더를 넣어 주고, 그 콜라이더는 Trigger로 만약 닿았다면 이 스크립트를 참조하여, col.enabled = true로 만들어 준다.
            //그러면 플레이어가 점프할 때는 바닥을 통과하고, 내려올 때는 바닥에서 떨어지지 않게 할 수 있다.
        }
    }
}



