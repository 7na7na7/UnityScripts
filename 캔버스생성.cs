using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class 캔버스생성: MonoBehaviour
{
    public Canvas homebtn;
     public void pause () {
        if(Time.timeScale==1)//정지 중이 아니면
        {
            Time.timeScale = 0;
            obj = (Canvas) Instantiate(homebtn);
        }
        else if(Time.timeScale==0)//정지 중이면
        {
            Time.timeScale = 1;
            Destroy(obj.gameObject);
        }
    }
}
