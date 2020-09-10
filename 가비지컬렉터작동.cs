using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 가비지컬렉터작동 : MonoBehaviour
{
    void Start()
    {
        System.GC.Collect();
    }
}
