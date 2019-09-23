using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 반올림 : MonoBehaviour
{
  //float 반올림 - Round
  float a = Mathf.Round(3.5f); //4f
  
  //float 올림 - Ceil
  float b = Mathf.Ceil(3.5f); //4f
  
  //float 내림 - Floor
  float c = Mathf.Floor(3.5f); //3f
  
  //int 반올림 - RoundToInt
  int A = Mathf.RoundToInt(3.5f); //4
  
  //int 올림 - CeilToInt
  int B = Mathf.CeilToInt(3.5f); //4
  
  //int 내림 - FloorToInt
  int C = Mathf.FloorToInt(3.5f); //3
  
  //만약 둘째 자리에서 반올림하고 싶다면 다음과 같이 응용할 수 있다.
  float a=Mathf.Round(3.56f*10) * 0.1f //3.6f가 됨
  //10을 곱하고 다시 10으로 나눈다!
}