using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createcube : MonoBehaviour //MainCamera에 들어감
{
   public float delay = 0;
   private void Start()
   {
      StartCoroutine(CreateCoroutine(delay));
   }

   IEnumerator CreateCoroutine(float delay)
   {
      while (true)
      {
         yield return new WaitForSeconds(delay);
         GameObject t_object = ObjectPoolingManager.instance.GetQueue(); //큐에 저장된 객체를 꺼냄
         t_object.transform.position=Vector3.zero;
      }
   }
}
