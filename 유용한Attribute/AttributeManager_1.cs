using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("SexyM/AtbMgr")] //이렇게 하면 인스펙터 창에서 Addcomponent로 SexyM-AtbMgr이 추가됨, 원래 있던 경로에 덮어씌우기도 가능
[System.Obsolete("이 코드엔 버그가 있을수도있고 없을수도 있습니다.")] //경고창 띄워줌(실행은 잘됨)
public class AttributeManager_1 : MonoBehaviour
{
  [UnityEditor.MenuItem("MyMenu/Menu")] //이걸 사용하여 static 함수를 만들면 유니티 에디터 위에 MyMenu를 클릭하고 Menu를 클릭하면 아래 함수가 실행된다.
  static void Menu()
  {
    print("UnityEditor.MenuItem - 메뉴 클릭함");
  }

  [ContextMenu("Doit")] //스크립트 우클릭으로 함수 호출가능, SexyM/Doit처럼 경로지정도 가능
  void Doit()
  {
    print("ContextMenu - 두잇!");
  }

  [ContextMenuItem("Random", "RandomNumber")] //첫 번째 인자로 이름, 두 번째 인자로 함수이름을 주면 그 함수를 실행한다. 이 함수는 인스펙터 창의 변수를 바로 바꾼다.
  [ContextMenuItem("Reset", "ResetNumber")] //인스펙터 창에서 변수를 우클릭하면 나온다.
  [Tooltip("랜덤값으로 조정할 수 있는 int형 변수입니다.")] //변수 위에 커서를 올리면 해당 툴팁이 뜬다.
  public int number;
  void RandomNumber()
  {
    number = Random.Range(0, 100);
  }
  void ResetNumber()
  {
    number = 0;
  }
}
