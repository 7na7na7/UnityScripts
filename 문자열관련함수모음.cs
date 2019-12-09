using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 문자열관련함수모음 : MonoBehaviour
{
    private void Start()
    {
        //문자열 치환(어떠한 문자를 다른 문자로 바꾸기)
        string str = "abc";
        str.Replace("abc", "cba"); // abc를 cba로 변경
        Debug.Log(str); //cba출력
        
        //문자열 자르기(특정 문자를 기준으로 배열을 이용해 나누기)
        string str2 = "123.456.789";
        string[] val2 = str.Split('.');   // .을 기준으로 나눈다. 결과값 : val[0] = 123 , val[1] = 456 ,
        
        //문자열 시작부터 자릿수까지 추출
        string str3 = "3214601485";
        string val3 = str.Substring(0,5);   // 시작부터 5자리 삭제( 결과값 32146)
        
        //문자열 중간부터 자릿수까지 추출
        string str4 = "3214601485";
        string val4 = str.Substring(5, 3);   // 5자리 제하고부터 3자리를 추출( 결과값 : 014 )
        
        //문자열 끝부터 자릿수 추출
        string str5 = "3214601485";
        string val5 = str.Remove(0, str.Length - 3);   // 뒤에서 3자리 남기고 삭제 ( 결과값 : 485 )

        //시작부터 특정 문자 앞까지 추출하기
        string str6 = "3214601485";   // 문자열
        string val6 = str.Substring(0, str.IndexOf("0"));   // 0까지의 문자열 반환, 결과값 : 32146

        //문자열 시작부터 자리수만큼 잘라내기
        string str7 = "3214601485";
        string val7 = str.Substring(3);   // 앞에서 3자리 잘라내기( 결과값 : 4601485 )

        //문자열 끝부터 자리수만큼 잘라내기
        string str8 = "3214601485";
        string val8 = str.Substring(0, str.Length - 4);   // 끝에서 4자리 잘라내기( 결과값 : 321

        //문자열 포함여부 찾기 및 확인
        string str9 = "3214601485";
        if (str9.Contains("014") == true)
        {
            Debug.Log("포함");
        }
        
        //특정 문자 포함여부
        string str10 = "abcdefg";
        if(str10.IndexOf("abc") >=0)   // 문자열에 abc가 포함되어 있는지 확인
        {
            Debug.Log("포함"); 
        }
        
        //문자열 속의 숫자만 추출하기 / 숫자이외의 문자열 치환하기
        using System.Text.RegularExpressions;
 
        string str11 = "A1B2C3";
        string val11 = Regex.Replace(str, @"\D", "");   // 결과값 : 123

        //문자열 공백제거
        string str = str.TrimStart();   // 문자열 앞쪽 공백제거
        string str = str.TrimEnd();   // 문자열 뒤쪽 공백제거
 
        string str = str.Trim();   // 문자열 앞뒤 공백 모두 제거
 
// 모든 공백제거는?
        string str = str.Replace(" ", ""); // 문자변경(치환)을 이용한다.

    }
}
