using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 롤방어력시스템 : MonoBehaviour
{
   public float HP = 100;
   public float damage = 100;
   public float armor = 100;
   private void Start()
   {
      float minusPer = 100 *((float)armor / (armor + 100f));
      HP -= damage-(damage * minusPer / 100f);
      print(HP); //50출력
   }
   /*
    * 정확한 계산식은 들어오는 공격을 100×{방어력 or 마법 저항력÷(방어력 or 마법 저항력+100)}%만큼 감소시키는 것으로,
    * 쉽게 설명하면 방어력(마법 저항력) 1당 상대적으로 체력이 1% 늘어나는 것이다. 예를 들어 방어력이 50일 때는 체력이 150%가 된 것과 마찬가지이므로 들어오는 물리 피해의 33%를 감소시키며,
    * 100일 때는 체력이 200%된 것과 동일하므로 들어오는 물리 피해의 50%를 감소시키며, 마찬가지로 200일 때는 66%를, 300일 때는 75%만큼의 물리 피해를 경감시켜 준다.
    */
}
