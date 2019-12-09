using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 에니메이션코드 : MonoBehaviour
{ 
    private Animation anim;
    private AnimationClip clip;

    void Start()
    {
        anim = GetComponent<Animation>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.Play("Moo_Bing"); //무빙 애니메이션 바로 실행
            anim.PlayQueued("Moo_Bing"); //현재 실행중인 애니메이션이 끝난 후 무빙 실행
            anim.Blend("Moo_Bing"); //무빙과 섞임
            anim.CrossFade("Moo_Bing"); //자연스럽게 현재 진행중인게 사라지고 전환
            if (!anim.IsPlaying("Moo_Bing")) //만약 무빙이 실행되지 않고 있다면
                anim.Play("Moo_Bing");
            anim.wrapMode = WrapMode.Loop; //반복재생으로
            anim.wrapMode = WrapMode.Once; //한번재생으로
            anim.wrapMode = WrapMode.PingPong; //왔다갔다~ 등등 있다.
            anim.clip = clip; //현재 클립에 클립을 넣음
        }

        if (Input.GetKeyDown(KeyCode.D))
            anim.Play("Moo_Bing_2"); //무빙2실행
        
        if(Input.GetKeyDown(KeyCode.A))
            anim.Blend("Moo_Bing"); //현재 실행중인 애니메이션과 무빙과 섞임
        
        if(Input.GetKeyDown(KeyCode.S))
            anim.Stop(); //모든 애니메이션 멈춤
    }
}
