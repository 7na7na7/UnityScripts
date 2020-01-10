using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //에셋 불러옴

public class ObjTween : MonoBehaviour
{
    public Transform pos;
    void Start()
    {
        /*
        transform.DOMove(Vector3 to, float duration, bool snapping);
        to : 이동하려는 최종 좌표값
        duration : 몇 초 동안 이동할 것있가.
        snapping : true이면 이동할때 정수단위로 이동한다.
        */
        
        //5초 동안 위로 이동, 1초 후 실행, 통통튀는움직임
        transform.DOMove(Vector2.up, 3).SetDelay(1).SetEase(Ease.InBounce);

        //5초 동안 스케일을 20,20으로 바꿈, 1초 후 실행 
        transform.DOScale(Vector2.one*20, 5).SetDelay(1);

        //5초 동안 오른쪽으로 60도 회전, 1초 후 실행
        transform.DORotate(Vector3.back*60, 5).SetDelay(1);

        //5초 동안 색을 빨강색으로 바꿈, 1초 후 실행
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        spr.DOColor(Color.red, 5).SetDelay(1);
    }
}
