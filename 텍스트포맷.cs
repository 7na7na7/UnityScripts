using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 텍스트포맷 : MonoBehaviour
{
    void Start()
    {
        //[F: 실수]----------------------------------------------
        //F0: 소수점 없이 표기 
        //F1: 소수점 한자리
        //F2: 소수점 두자리
        float f = 1234.56f;
        print(string.Format("{0:F0} {1:F1} {2:F2}",f,f,f));

        //[N: 자릿수를 표기하는 실수]-----------------------------
        //N0: 소수점 없이 표시 + 천단위마다
        //N1: 소수점 한자리 +천단위마다
        //N2: 소수점 두자리 +천단위마다
        print(string.Format("{0:N0} {1:N1} {2:N2}", f, f, f));

        //[P: 백분률]--------------------------------------------
        //P0: % 로 표기. 0.3f-> 30 %
        float p = 0.3f;
        print(p.ToString("P0"));

        //[D: 0을 붙이는 정수]-----------------------------------
        //D0: 123
        //D4: 네자리 0123
        //D5: 다섯자리 00123
        int z = 123;
        print(string.Format("{0:D0} {1:D4} {2:D5}", z, z, z));
    }
}
