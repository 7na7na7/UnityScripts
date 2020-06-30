using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixScript : MonoBehaviour
{
    public List<string> mixList = new List<string>() {"앙기", "모띠", "철권7", "엔터더건전", "아이작"}; //원래 리스트

    public void Mix()
    {
        List<string> list=new List<string>(); //섞기 위해서 리스트 함수를 사용해야 한다. 임시 리스트를 생성해준다.
        int count = mixList.Count;
        for (int i = 0; i < count; i++)
        {
            int random = Random.Range(0, mixList.Count); //원래리스트중에 하나를 무작위로 고름
            list.Add(mixList[random]); //그걸 임시 리스트에 넣음
            mixList.RemoveAt(random); //원래 리스트에 있던 것을 삭제함, 그럼이제 그건 안나오겠지?
        }
        mixList = list; //셔플이 끝난 후 원래 리스트를 셔플된 임시 리스트로 교체해준다.
    }
}
