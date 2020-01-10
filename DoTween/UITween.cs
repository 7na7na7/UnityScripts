using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

//트위닝 에셋 사용
public class UITween : MonoBehaviour
{
    void Start()
    {
        //1초 동안 RectTransform의 Y값을 -300으로 만듬, Elastic효과로 개멋지게
        RectTransform rt = GetComponent<RectTransform>();
        rt.DOAnchorPosY(-300,1).SetEase(Ease.OutElastic);

        //2초 동안 텍스트를 스크램블 효과를 주며 바꿈, 1초 후 실행
        Text text = GetComponent<Text>();
        text.DOText("Into the Unknown~", 2, true, ScrambleMode.None).SetDelay(1);
    }
}
