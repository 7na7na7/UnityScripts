using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoTweenValueTween : MonoBehaviour
{
    void Start()
    {
        DOTween.To(() => 트윈할값, x => 트윈할값 = x, 목표값, 시간);
    }
}
