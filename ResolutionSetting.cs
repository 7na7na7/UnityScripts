using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSetting : MonoBehaviour
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;

   public class ResolutionSetting : MonoBehaviour
   {
      private void Awake()
      {
         SetRes(false);
      }

    
      public void SetRes(bool isPortrait)
      {
         //남는부분을 Rect를 조정하려 래터박스로 채울 수 있다!
         Camera camera = GetComponent<Camera>();
         Rect rect = camera.rect;

         float scaleHeight, scaleWidth;
         if (isPortrait)
         {
            //세로로 하는게임의경우
            scaleHeight = ((float) Screen.width / Screen.height) / ((float) 9 / 16); //가로/세로
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
         }
         else
         {
            //      가로로 눕히는게임의경우
            scaleWidth = ((float) Screen.width / Screen.height) / ((float) 16 / 9); //가로/세로
            scaleHeight= 1f / scaleWidth;
            if (scaleHeight < 1) //세로가 넓은경우
            {
               rect.width = scaleWidth;
               rect.x = (1f - scaleWidth) / 2f;
            }
            else //가로가 넓은경우
            {
               rect.height = scaleHeight;
               rect.y = (1f - scaleHeight) / 2f;
            }
         }
     
         camera.rect = rect;
      }
   }

}
