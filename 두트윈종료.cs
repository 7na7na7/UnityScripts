using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class 두트윈종료 : MonoBehaviour
{
    Sequence mySequence = DOTween.Sequence();

    void Start()
    {
        mySequence.Kill(); 
    }

}
