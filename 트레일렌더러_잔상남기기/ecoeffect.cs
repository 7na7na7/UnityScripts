using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ecoeffect : MonoBehaviour
{
   public float timeBtwSpawns;
   public float startTimeBtwSpawns;

   public GameObject echo;

   private void Update()
   {
      if (timeBtwSpawns <= 0)
      {
         GameObject ball=Instantiate(echo, transform.position, Quaternion.identity);
         Destroy(ball,1f);
         timeBtwSpawns = startTimeBtwSpawns;
      }
      else
      {
         timeBtwSpawns -= Time.deltaTime;
      }
   }
}
