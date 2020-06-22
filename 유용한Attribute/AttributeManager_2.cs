using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HelpURL("https://www.youtube.com/watch?v=_rS7vtM_Dfk")] //URL링크 연결 가능, 물음표 아이콘 클릭시 연결됨
public class AttributeManager_2 : MonoBehaviour
{
   [ColorUsage(true,true)] //첫 번째 인자 값은 알파값 포함 여부, 두 번째는 HDR(채도) 포함 여부 
   public Color color;

   [Header("A")] //비슷한 역할의 변수들끼리 묶어주는 헤더 역할을 함
   public int Africa;
   public int Accelerate;
   
   
   [Header("B")] 
   public int Brother;
   public int Broken;

   public int a;
   [Space(20)] //거리두기, 20만큼 A와 B사이에 거리를 둠
   public int b;

   [Multiline(3)] //string형에 사용가능, 3줄까지 보이게 함
   public string Multiline;

   [TextArea(3, 6)] //Multiline과 비슷하지만 보이는 수 최솟값도 조절가능, 더 늘어나면 스크롤바로 내릴 수 있음
   public string Miltiline_2;

   [SerializeField] //private변수도 인스펙터 창에 보이게 함
   private int privateValue;

   [HideInInspector] //public변수기 인스펙터 창에 안 보이게 됨
   public int publicValue; 
}
