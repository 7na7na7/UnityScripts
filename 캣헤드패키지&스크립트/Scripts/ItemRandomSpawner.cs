using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemRandomSpawner : MonoBehaviour
{
   public float leastX, maxX;
   public float leastY, maxY;
   public GameObject item;
   public float delay;

   private void Start()
   {
      StartCoroutine(spawn());
   }

   IEnumerator spawn()
   {
      while (true)
      {
         yield return new WaitForSeconds(delay);
         Instantiate(item, new Vector3(Random.Range(leastX, maxX), Random.Range(leastY, maxY), 0), Quaternion.identity);
      }
   }
}
