using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 유니티실행시최초한번실행
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void FirstLoad()
    {
        Debug.Log("최초 한번");
    }
}
