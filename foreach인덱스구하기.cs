using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class foreach인덱스구하기 : MonoBehaviour
{
    public Transform[] trs;
    private void Start()
    {
        foreach (var tr in trs)
            print(tr.GetSiblingIndex());
        //0 1 2 3 4 이렇게 출력해준다
    }
}
