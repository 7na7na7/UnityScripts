using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 해시테이블 : MonoBehaviour
{
    private Hashtable userInfoHash;

    private void Start()
    {
        userInfoHash=new Hashtable();

        //해시에 값넣기
        for (int i = 0; i < 10; i++)
        {
            userInfoHash.Add(i,"user"+i);
        }
        
        //삭제하기
        if (userInfoHash.ContainsKey(0)) //키값 0을 포함하고 있다면
        {
            userInfoHash.Remove(0); //삭제
        }
        
       //값 대입하기
       if (userInfoHash.ContainsKey(1)) //키값이 1이면
       {
           userInfoHash[1] = "변경된 값!";
       }
       
       //반복문쓰기
       foreach (DictionaryEntry entry in userInfoHash)
       {
           print("키값 : " + entry.Key+ ", 밸류값 : " + entry.Value);
       }
       
    }
}
