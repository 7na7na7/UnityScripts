using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 홈키종료함수 : MonoBehaviour
{
    private bool bPaused;

    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            bPaused = true;
            // todo : 어플리케이션을 내리는 순간에 처리할 행동들 

        }
        else
        {
            if (bPaused)

            {
                bPaused = false;
                // todo : 내려놓은 어플리케이션을 다시 올리는 순간에 처리할 행동들 
            }
        }

    }

    void OnApplicationQuit()

        {
            // todo : 어플리케이션을 종료하는 순간에 처리할 행동들

        }
        
}
