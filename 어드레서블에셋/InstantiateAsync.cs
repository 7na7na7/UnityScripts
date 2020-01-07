using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class InstantiateAsync : MonoBehaviour
{
   public GameObject obj;
   public AssetReference Ref;

   private void Start()
   {
      //obj의 위치에 Ref생성
      Ref.InstantiateAsync(obj.transform);
   }
}
