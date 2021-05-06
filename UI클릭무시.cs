using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI클릭무시 : MonoBehaviour
{
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ()) //만약 포인터가 UI위가 아니라면
      {
        print("실행!");
      }
      else
      {
        print("포인터가 UI위에 있어서 인식 못함!");
      } 
    }
  }
}
