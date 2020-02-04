using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 인터넷연결확인 : MonoBehaviour
{
    void Start()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            print("인터넷에 연결되지 않음!");
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            print("데이터로 연결됨!");
        }
        else
        {
            print("와이파이로 연결됨!");
        }
    }
}
