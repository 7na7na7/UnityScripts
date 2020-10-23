using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTemplates : MonoBehaviour
{
   public int minRoomCount = 7;
   public int maxRoomCount = 50;
   public int maxRoomCountSave;
   public int PlayerCount = 4;
   public int PlayerSpawnMinusValue = 3;
   public GameObject[] bottomRooms;
   public GameObject[] topRooms;
   public GameObject[] leftRooms;
   public GameObject[] rightRooms;
   
   
   public GameObject closedRoom;

   public List<GameObject> rooms;

   public float waitTime;
   public GameObject boss;
   public GameObject player;
   

   private void Start()
   {
      Invoke("Spawn",waitTime);
      Invoke("ReLoad",2.5f);
   }

   void ReLoad()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
   void Spawn()
   {
      Instantiate(boss, rooms[rooms.Count-1].transform.position, quaternion.identity);
      for (int i = 0; i < rooms.Count-1; i++)
      {
         if (rooms[i].CompareTag("Entry"))
         {
            Instantiate(player, rooms[i].transform.position, quaternion.identity);
            PlayerCount--;
         }
      }
      if(PlayerCount>0)
         ReLoad();
   }
}
