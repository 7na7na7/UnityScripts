using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 래터박스 : MonoBehaviour
{
    public Vector2 resolution;
    public bool isOn = true;
   private void Awake()
   { 
      if(isOn) 
      {
          SetRes();
      }
   }
   public void SetRes()
   {
      //남는부분을 Rect를 조정하려 래터박스로 채울 수 있다!
      Camera camera = GetComponent<Camera>();
      Rect rect = camera.rect;

      float scaleHeight, scaleWidth;

      //세로로 하는게임의경우
      scaleHeight = ((float) Screen.width / Screen.height) / ((float) resolution.x / resolution.y); //가로/세로
      scaleWidth = 1f / scaleHeight;
      if (scaleHeight < 1) //세로가 넓은경우
      {
         rect.height = scaleHeight;
         rect.y = (1f - scaleHeight) / 2f;
      }
      else //가로가 넓은경우
      {
         rect.width = scaleWidth;
         rect.x = (1f - scaleWidth) / 2f;
      }

      camera.rect = rect;
   }
}
