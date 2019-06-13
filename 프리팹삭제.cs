using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 프리팹삭제 : MonoBehaviour
{
    public GameObject spike;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.space))//스페이스바 누를시
        {
            Object obj = Instantiate(spike, tr); //이걸로 생성
            Destroy(obj, 3.0f); //이걸로 3초 후에 삭제
        }
    }
}



