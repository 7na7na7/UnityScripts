using UnityEngine;
using System.Collections;
using UnityEngine.UI;//이거 필요함

public class slider: MonoBehaviour
{
    public Slider slider; //슬라이더의 value값은 인스펙터에서 조정가능
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))//스페이스바를 누르고 있는 중에는
            slider.value--;//슬라이더의 값이 1씩 바뀜
    }
}
