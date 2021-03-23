using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class 스트링바이트 : MonoBehaviour
{
// 바이트 배열을 String으로 변환
    private string ByteToString(byte[] strByte)
    {
        string str = Encoding.Default.GetString(strByte); return str;
    } 
    // String을 바이트 배열로 변환
    private byte[] StringToByte(string str)
    {
        byte[] StrByte = Encoding.UTF8.GetBytes(str); return StrByte;
    }
}
