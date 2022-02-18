using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 은는을를이가 : MonoBehaviour
{
    void Start()
    {
        print("값::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::   " + GetCompleteWord("화둔", "이", "가") + "     " + GetCompleteWord("도구", "이", "가"));
    }

    string GetCompleteWord(string name, string firstVal, string secondVal)
    {
        char lastChar = name[name.Length - 1];
        int index = (lastChar - 0xAC00) % 28;
        if (lastChar < 0xAC00 || lastChar > 0xD7A3) { return "한글 범위에서 벗어났습니다."; }
        string selectVal = (lastChar - 0xAC00) % 28 > 0 ? firstVal : secondVal;
        return name + selectVal;
    }
}
