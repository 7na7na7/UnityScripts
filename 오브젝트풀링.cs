using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 오브젝트풀링 : MonoBehaviour
{
   public int bulletNum;

   //프리팹 할당
   public GameObject Green1Obj;
   public GameObject Mint1Obj;

   public GameObject Green2Obj;
   public GameObject Mint2Obj;

   public GameObject Green3Obj;
   public GameObject Mint3Obj;

   public GameObject Green4Obj;
   public GameObject Mint4Obj;

   public GameObject GreenClusterObj;

   public GameObject MintClusterObj;
   //===================================================================

   //오브젝트풀링 배열
   private GameObject[] Green1; //플레이어방향직진
   private GameObject[] Mint1;

   private GameObject[] Green2; //유도탄
   private GameObject[] Mint2;

   private GameObject[] Green3; //네모, 갈라지고 유도탄 두개
   private GameObject[] Mint3;

   private GameObject[] Green4; //랜덤방향직진
   private GameObject[] Mint4;

   private GameObject[] GreenCluster; //네모에서 나온 유도탄
   private GameObject[] MintCluster;


   public static ObjectManager instance;

   void Awake()
   {
      //싱글톤
      if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject);
      }
      else
      {
         Destroy(gameObject);
      }

      //동시에 나타날 수 있는 탄막의 최대 개수를 배열에 넣어줌
      Green1 = new GameObject[40];
      Mint1 = new GameObject[40];

      Green2 = new GameObject[60];
      Mint2 = new GameObject[60];

      Green3 = new GameObject[20];
      Mint3 = new GameObject[20];

      Green4 = new GameObject[40];
      Mint4 = new GameObject[40];

      GreenCluster = new GameObject[60];
      MintCluster = new GameObject[60];


      Generate();
   }

   void Generate()
   {
      //풀에 오브젝트들을 넣어줌

      #region pooling

      for (int i = 0; i < Green1.Length; i++)
      {
         Green1[i] = Instantiate(Green1Obj,transform);
         Green1[i].SetActive(false);
      }

      for (int i = 0; i < Green2.Length; i++)
      {
         Green2[i] = Instantiate(Green2Obj,transform);
         Green2[i].SetActive(false);
      }

      for (int i = 0; i < Green3.Length; i++)
      {
         Green3[i] = Instantiate(Green3Obj,transform);
         Green3[i].SetActive(false);
      }

      for (int i = 0; i < GreenCluster.Length; i++)
      {
         GreenCluster[i] = Instantiate(GreenClusterObj,transform);
         GreenCluster[i].SetActive(false);
      }

      for (int i = 0; i < Green4.Length; i++)
      {
         Green4[i] = Instantiate(Green4Obj,transform);
         Green4[i].SetActive(false);
      }

      for (int i = 0; i < Mint1.Length; i++)
      {
         Mint1[i] = Instantiate(Mint1Obj,transform);
         Mint1[i].SetActive(false);
      }

      for (int i = 0; i < Mint2.Length; i++)
      {
         Mint2[i] = Instantiate(Mint2Obj,transform);
         Mint2[i].SetActive(false);
      }

      for (int i = 0; i < Mint3.Length; i++)
      {
         Mint3[i] = Instantiate(Mint3Obj,transform);
         Mint3[i].SetActive(false);
      }

      for (int i = 0; i < MintCluster.Length; i++)
      {
         MintCluster[i] = Instantiate(MintClusterObj,transform);
         MintCluster[i].SetActive(false);
      }

      for (int i = 0; i < Mint4.Length; i++)
      {
         Mint4[i] = Instantiate(Mint4Obj,transform);
         Mint4[i].SetActive(false);
      }

      #endregion
   }

   public GameObject MakeObj(int index)
   {
      switch (index)
      {
         case 0:
            for (int i = 0; i < Green1.Length; i++)
            {
               if (!Green1[i].activeSelf) //비활성화되어있다면
               {
                  Green1[i].SetActive(true);
                  return Green1[i];
               }
            }
            break;
         case 1:
            for (int i = 0; i < Mint1.Length; i++)
            {
               if (!Mint1[i].activeSelf) //비활성화되어있다면
               {
                  Mint1[i].SetActive(true);
                  return Mint1[i];
               }
            }
            break;
         case 2:
            for (int i = 0; i < Green2.Length; i++)
            {
               if (!Green2[i].activeSelf) //비활성화되어있다면
               {
                  Green2[i].SetActive(true);
                  return Green2[i];
               }
            }
            break;
         case 3:
            for (int i = 0; i < Mint2.Length; i++)
            {
               if (!Mint2[i].activeSelf) //비활성화되어있다면
               {
                  Mint2[i].SetActive(true);
                  return Mint2[i];
               }
            }
            break;
         case 4:
            for (int i = 0; i < Green3.Length; i++)
            {
               if (!Green3[i].activeSelf) //비활성화되어있다면
               {
                  Green3[i].SetActive(true);
                  return Green3[i];
               }
            }
            break;
         case 5:
            for (int i = 0; i < Mint3.Length; i++)
            {
               if (!Mint3[i].activeSelf) //비활성화되어있다면
               {
                  Mint3[i].SetActive(true);
                  return Mint3[i];
               }
            }
            break;
         case 6:
            for (int i = 0; i < Green4.Length; i++)
            {
               if (!Green4[i].activeSelf) //비활성화되어있다면
               {
                  Green4[i].SetActive(true);
                  return Green4[i];
               }
            }
            break;
         case 7:
            for (int i = 0; i < Mint4.Length; i++)
            {
               if (!Mint4[i].activeSelf) //비활성화되어있다면
               {
                  Mint4[i].SetActive(true);
                  return Mint4[i];
               }
            }
            break;
         case 8:
            for (int i = 0; i < GreenCluster.Length; i++)
            {
               if (!GreenCluster[i].activeSelf) //비활성화되어있다면
               {
                  GreenCluster[i].SetActive(true);
                  return GreenCluster[i];
               }
            }
            break;
         case 9:
            for (int i = 0; i < MintCluster.Length; i++)
            {
               if (!MintCluster[i].activeSelf) //비활성화되어있다면
               {
                  MintCluster[i].SetActive(true);
                  return MintCluster[i];
               }
            }
            break;
      }
      return null;
   }
   
   //그 후, Destroy함수를 SetActive함수로 교체
}
