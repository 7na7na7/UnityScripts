using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoTweenPath : MonoBehaviour
{
    public Transform player;
    public PathType pathtype = PathType.CatmullRom;

    public Vector3[] paths;
    private Tween tween;
    void Start()
    {
        tween = player.transform.DOPath(paths, 3, pathtype);
        tween.SetEase(Ease.Linear).SetLoops(-1); //일정한 속도로 움직임, 반복
    }
}
