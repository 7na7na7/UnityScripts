using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineCtrl : MonoBehaviour
{
    //스파인 애니메이션을 위한 것
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] animClips;

    //애니메이션에 대한 Enum
    public enum AnimState
    {
Idle,Walk
    }

    //현재 애니메이션 처리가 무엇인지에 대한 변수
    private AnimState animState;

    //현재 어떤 애니메이션이 재생되고 있는지에 대한 변수
    private string CurrentAnimation;

    //이동
    private Rigidbody2D rigid;
    private float xx;

    private void Awake() => rigid = GetComponent<Rigidbody2D>();

    private void Update()
    {
        xx = Input.GetAxisRaw("Horizontal");
        if (xx == 0f)
            animState = AnimState.Idle;
        else
        {
            animState = AnimState.Walk;
            transform.localScale = new Vector2(xx, 1);
        }
        //애니메이션 적용
        SetCurrentAnimation(animState);

        //이동
        rigid.velocity = new Vector2(xx * 5, rigid.velocity.y);
    }

    //애니메이션 변경 함수
    private void AsyncAnimation(AnimationReferenceAsset animClip, bool isLoop, float timeScale)
    {
        //동일 애니메이션 실행 방지
        if (animClip.name.Equals(CurrentAnimation))
            return;

        skeletonAnimation.state.SetAnimation(0, animClip, isLoop).TimeScale = timeScale;
        skeletonAnimation.loop=isLoop;
        skeletonAnimation.timeScale=timeScale;
        CurrentAnimation = animClip.name; //현재 애니메이션 이름 변경
    }

    private void SetCurrentAnimation(AnimState state)
    {
        AsyncAnimation(animClips[(int)state], true, 1f);
    }
}
