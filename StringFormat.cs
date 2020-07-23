using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringFormat : MonoBehaviour
{
    //출처 : https://m.blog.naver.com/PostView.nhn?blogId=pxkey&logNo=221321776845&proxyReferer=https:%2F%2Fwww.google.com%2F
    void Start()
    {
        Debug.Log(string.Format("a의 값은 {0}이다.",10));  //a의 값은 10이다. (단순히 끼워넣기)
        
        int a = 10, b = 2;
        print(string.Format("{0}x{1}={2}", a, b, a * b)); //10x2=20 (변수도 넣을수있음)

        print(string.Format("{0:F2}", 3.141592)); //3.14 
        print(string.Format("{0:F0}", 3.141592)); //3 
        // (소수점도 원하는 데까지 없앨수있음)
        
        DateTime date1 = new DateTime(2019, 11, 11);
        System.Globalization.CultureInfo culture = 
            new System.Globalization.CultureInfo("en-US"); 
        // (첫 번째 인수로 System.Globalization.CultureInfo타입으로 국가를 받아 출력 언어를 다르게 할 수 있다)
        
        print(string.Format(culture,"{0:D}", date1)); //2019년 11월 11일 월요일 (DateTime타입 D로 받아서 날짜출력가능)
        
        print(string.Format("{0}",Mathf.Round(3.5f))); // 4 (반올림)
        
        print(string.Format("{0}",Mathf.Ceil(3.5f))); // 4 (올림)
        
        print(string.Format("{0}",Mathf.Floor(3.5f))); // 3 (내림)
        

        print(string.Format("2019년 최저임금 : {0:N0}",8350)); // 2019년 최저임금 : 8,350 (세 자리마다 콤마)

        print(string.Format("2019년 최저임금 : {0:D6}",8350)); // 2019년 최저임금 : 008350 (전체 자릿수 고정)
        
        print(string.Format("2018년 대비 {0:P} 상승",0.109)); // 2018년 대비 10.90 % 상승 (퍼센트 표시 가능)
        print(string.Format("2018년 대비 {0:P1} 상승",0.109)); // 2018년 대비 10.9 % 상승 (P다음에 오는 숫자로 소수점 조절 가능)
    }
}
