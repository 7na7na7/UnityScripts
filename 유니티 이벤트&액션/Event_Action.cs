using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] //이렇게 해야 인스펙터에 보인다!
public class EventString : UnityEvent<String> //이렇게 하면 매개변수를 String으로 강제할 수 있다!
{
    
}
public class Event_Action : MonoBehaviour
{
    public EventString event_string;
    public UnityEvent onInputSpace;
    public UnityAction<string> Action; //액션은 이벤트와 다르게 인스펙터 표시 

    private void Start()
    {
        Action += print1; //이걸로 추가나
        Action += print2;
        //Action -= print1; //이걸로 삭제 가능
        
       event_string.AddListener(Action);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onInputSpace.Invoke(); //이렇게 이벤트 실행
            event_string.Invoke("Ang");
        }
    }

    void print1(string a)
    {
        print("print1 : "+a);
    }
    void print2(string a)
    {
        print("print2 : "+a);
    }
    public void StringFunc(string s)
    {
        print(s);
    }
}
