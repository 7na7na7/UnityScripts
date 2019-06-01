using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 더월드 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.timeScale == 1.0F)
                Time.timeScale = 0.7F;
            else
                Time.timeScale = 1.0F;
            //yield return new WaitForSecondsRealtime(0.8f); WaitForSecondsRealtime은 timeScale의 영향을 받지 않는다. timeScale이 0이 되면 이거쓰자.
        }
    }
}
/*
Time.timeScale을 조정하면Time.fixedDeltaTime도 조정해 주면 좋다.별도의 타이머이기 때문이다.
Time.fixedDeltaTime = 0.02f * Time.timeScale 이렇게 해주는 것이 좋다.
여기서 0.02f는유니티 엔진이 물리 연산을 담당하는
FixedUpdate() 메소드를 초당 50회(1초/50회 = 0.02f) 호출하기 때문이다.*/


