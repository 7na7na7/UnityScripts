using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieType{Normal, Power, Sight,Speed,Big}
public class ZombieSpawner : MonoBehaviour
{
   [SerializeField] private List<ZombieData> zombieDats; //데이터 넣을때 위 enum열거형 순서대로 넣어줘야한다.
   [SerializeField] private GameObject zombiePrefab;

   private void Start()
   {
      for (int i = 0; i < zombieDats.Count; i++)
      {
         var zombie = SpawnZombie((ZombieType) i);
         zombie.PrintZombieData();
      }
   }

   public Zombie SpawnZombie(ZombieType type)
   {
      var newZombie = Instantiate(zombiePrefab).GetComponent<Zombie>();
      newZombie.zombieData=zombieDats[(int)type];
      newZombie.name = newZombie.zombieData.ZombieName;
      return newZombie;
   }
}
