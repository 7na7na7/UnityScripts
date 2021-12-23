using System;
using UnityEngine;
using System.Collections;

public class 람다식할당 : MonoBehaviour
{
    public bool isDead = false;
    public int hp = 10; 

    public int Health => isDead ? 0 : hp;
    //위의 =>는 이런 뜻이다!
    /*
    public int Health
    {
        get
        {
            return isDead ? hp : 0;
        }
    }
    */

    private void Start()
    {
        print(Health);
    }
}