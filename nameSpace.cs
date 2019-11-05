using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using mingu.sexym; //이것으로 sexym안의 namespace를 사용한다.
using mingu; //이것으로 mingu안의 namespace를 사용한다.

namespace mingu //mingu라는 이름의 namespace선언 
{
    public class minguClass
    {
        public int age = 17;
    }
    namespace sexym
    {
        public class minguClass
        {
            private string name="";

            public void SetName(string myname) //이름 정하는 함수
            {
                name = myname;
            }

            public bool isname() //이름이 있는지 없는지 참/거짓 값을 반환
            {
                return name != "";
                //이름이 비어 있으면 false반환, 들어 있다면 true반환
            }
        }
    }
}
public class nameSpace : MonoBehaviour
{
    mingu.sexym.minguClass mingu_class= new mingu.sexym.minguClass(); //네임스페이스 안에 들어 있는 minguClass객체를 하나 만듬
  mingu.minguClass mingu_class_2=new mingu.minguClass(); //위에거랑 다르다. 이건 mingu 네임스페이스 안에 있는 거다.
    void Start()
    {
        mingu_class.SetName("민구");//mingu라는 이름을 클래스에 넣어 줌
        Debug.Log("민구의 이름이 제대로 들어갔는가? : "+mingu_class.isname());//이름이 들어 있으므로 true출력
        Debug.Log("민구의 나이 : "+mingu_class_2.age);
    }
}
