using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ref_out_이뭘까요 : MonoBehaviour
{
    private int num = 3;
    void Start()
    { 
        print("변경 전 num : "+num);
       //Func(num); //함수 안에서 변경하였으므로 값 변경 X
       refFunc(ref num); //ref를 이용하여 참조 연산을 수행하였으므로 값 변경 O
       print("변경 후 num : "+num);
       
       //판을 만든다.
       Plane plane=new Plane(Vector3.back,10);
       //카메라와 마우스를 통과하는 빛을 만든다.
       Ray ray =Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
       float depth; //빛의 깊이
       //광선(ray)이 판(plane)에 닿았다면
       if (plane.Raycast(ray, out depth)) //광선이 닿았으면 depth에 정보가 기록된다. out을 쓰지 않으면 전달되지 않는다!(중요)
       
       //out은 ref와 비슷하지만, 초기화되지 않은 변수에도 사용할 수 있다는 장점이 있다.
    }
    void refFunc(ref int _num)
    {
        _num++;
    }

    void Func(int _num)
    {
        _num++;
    }
}
