using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ���������̰� : MonoBehaviour
{
    void Start()
    {
        print("��::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::   " + GetCompleteWord("ȭ��", "��", "��") + "     " + GetCompleteWord("����", "��", "��"));
    }

    string GetCompleteWord(string name, string firstVal, string secondVal)
    {
        char lastChar = name[name.Length - 1];
        int index = (lastChar - 0xAC00) % 28;
        if (lastChar < 0xAC00 || lastChar > 0xD7A3) { return "�ѱ� �������� ������ϴ�."; }
        string selectVal = (lastChar - 0xAC00) % 28 > 0 ? firstVal : secondVal;
        return name + selectVal;
    }
}
