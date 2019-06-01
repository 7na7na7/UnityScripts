using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 페이드: MonoBehaviour
{
    //일단 Canvas-panel을 생성하고 panel의 A값을 255로하여 검은색으로 만든다.(흰색도 하고싶음하고)
    public UnityEngine.UI.Image fade;
    float fades = 1.0f;
    float time = 0;

    void Update()
    {
        time += Time.deltaTime;
        if (fades > 0.0f && time >= 0.1f)
        {
            fades -= 0.1f;
            fade.color = new Color(0, 0, 0, fades);
            time = 0;
        }
        else if (fades <= 0.0f)
        {
            //이곳은 다음씬이나 다음 행동을 적는다.
            time = 0;
        }
    }
}

