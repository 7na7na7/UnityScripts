using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
   public float speed;
   public float delay;
   public static Flash instance;
   private Image img;
   private void Awake()
   {
      instance = this;
      img = GetComponent<Image>();
   }

   public void flash()
   {
      StopAllCoroutines();
      StartCoroutine(flashCor());
   }
   IEnumerator flashCor()
   {
      Color color = Color.white;
      img.color = color;
      yield return new WaitForSeconds(delay);
      while (img.color.a>0)
      {
         color.a -= speed;
         img.color = color;
         yield return new WaitForSeconds(delay);
      }
      yield break;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         flash();
      }
   }
}
