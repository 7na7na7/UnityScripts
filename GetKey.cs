using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
      void OnGUI()
       {
           print(Event.current.keyCode);
           if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Space.ToString())))
           {
               Debug.Log("스페이스 키가 눌렸습니다!");
           }
       }
}
