using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 이동회전크기 : MonoBehaviour
{
    //이동
    
    
    
    transform.position = new Vector3(x, y, z);
    //가장 간단한 방법으로 GameObject의 위치를 직접 지정해 줄 수 있다.
    
    transform.Translate(speed, 0, 0);
    //현재 위치를 기준으로 x축으로 움직이고 싶다면 위와같이 쓸 수 있다.

    
    transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    //target 오브젝트에게 일정하게 이동하고 싶다면 위와같이 MoveToward를 쓰면 된다.



    
    //회전
    //절대적인 이동이다. transform.position과 비슷하다.
    transform.rotation = Quaternion.identity;
    
    //Quaternion 값으로 지정해야하며
    Quaternion.identity //는 기본값인 (0,0,0)을 나타낸다.
    //Quaternion에 대한 정보는 링크를 참조하자. ( http://docs.unity3d.com/ScriptReference/Quaternion.html )
    
    //상대적인 이동이다. transform.Translate와 비슷하다.
    transform.Rotate(Vector3.up, speed, Space.World);
    //Rotate를 사용하여 현재 회전값을 기준으로 회전시킬 수 있다.
    //매개변수에는 축, 각도, 기준좌표계가 들어간다.
    
    transform.LookAt(target)
    //target의 position 정보가있고 이 위치를 향해 바라보고 싶다면 위와같이 LookAt을 사용할 수 있다.
    
    //하지만 이는 한번에 회전하므로 천천히 target을 향해 회전하도록 하고 싶다면 아래와 같이 RotateTowards를 사용한다.
    transform.rotation = Quaternion.RotateTowards(transform.rotation, target.position - transform.position, speed);
    
    
    

    //크기
    
    transform.localScale = new Vector3(1, 1, 1);
    //원하는 크기로 변경하고 싶다면 위와같이 사용할 수 있다.

    transform.localScale += new Vector3(1, 0, 0);
    //현재 크기를 기준으로 x축으로 늘리고 싶다면 위와같이 사용할 수 있다.



    Time.deltatime

    /*
    GameObject를 연속적으로 이동하거나 회전시킬때 Update문에서 구현하게 된다.
    하지만 이는 매 프레임마다 호출되는 Update 특성 상 PC의 성능에 따라 프레임횟수가 다르기 때문에 문제가 발생한다.
    즉, 같은 속도값을 주더라도 좋은PC와 안좋은PC에서 움직이는 속도가 다르게된다.
    이는 속도값에 Time.deltatime을 곱해 해결할 수 있다.
    Time.deltatime을 간단히 설명하자면 전프레임이 완료되기까지 걸린 시간으로 성능이 느릴수록 값이 커지는 특성이 있다.
    그럼 speed값을 정의할때 다음과 같이 쓰면 되겠다.
    */

    //출처: https://cpp11.tistory.com/16 [fullstack]
}
