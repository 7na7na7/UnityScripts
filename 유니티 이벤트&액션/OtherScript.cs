using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherScript : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<Event_Action>().onInputSpace.AddListener(Space); //이렇게 추가 가능!
        //FindObjectOfType<Event>().onInputSpace.RemoveListener(hello); //이렇게 삭제 가능!
    }

    void Space()
    {
        print("스페이스 키가 눌렸어요!");
    }
}
