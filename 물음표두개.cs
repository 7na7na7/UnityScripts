using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 물음표두개 : MonoBehaviour
{
    void Start()
    {
        GameObject a = null;
        GameObject b = this.gameObject;
        GameObject c = a ?? b; //a가 null이므로 대신 b가 들어간다.
        print(c.name);
    }
}
