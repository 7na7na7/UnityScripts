using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
   public ZombieData zombieData;

   public void PrintZombieData()
   {
      print("좀이이름 :: " +zombieData.ZombieName);
      print("체력 :: " +zombieData.Hp);
      print("공격력 :: " +zombieData.Damage);
      print("시야 :: " +zombieData.SightRange);
      print("이동속도 :: " +zombieData.MoveSpeed);
      print("--------------------------------------");
   }
}
