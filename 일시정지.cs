using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 일시정지 : MonoBehaviour
{
    private bool isPause = true;

    public void pause () {
        if(isPause){
            Time.timeScale = 0;
            isPause = false;
        }else{
            Time.timeScale = 1;
            isPause = true;
        }
    }
}
