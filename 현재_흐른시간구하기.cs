using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

public class 현재_흐른시간구하기 : MonoBehaviour
{
    public string url = "";
    private void Start()
    {
        /*
        TimeSpan timestamp = DateTime.UtcNow - new DateTime
                                 (1970, 1, 1, 0, 0, 0);
        int past = PlayerPrefs.GetInt("sec", (int) timestamp.TotalSeconds);
        PlayerPrefs.SetInt("sec",(int)timestamp.TotalSeconds);
        print((int)timestamp.TotalSeconds-past); //지난시간 출력
        //이 방법은 디바이스의 시간을 조작하면 바꿀 수 있기 때문에 안좋다.
        */

        StartCoroutine(WebChk());
    }

    IEnumerator WebChk()
    {
        UnityWebRequest request=new UnityWebRequest();
        using (request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                string date = request.GetResponseHeader("date");
                //Debug.Log(date); //해당 웹사이트에서 시간 출력

                DateTime dateTime = DateTime.Parse(date).ToUniversalTime();
                TimeSpan timestamp = dateTime - new DateTime(1970, 1, 1, 0, 0, 0);

                int stopwatch = (int) timestamp.TotalSeconds - PlayerPrefs.GetInt("net", (int) timestamp.TotalSeconds);
                Debug.Log(stopwatch+"sec");
                PlayerPrefs.SetInt("net", (int)timestamp.TotalSeconds);
            }
        }
    }
    void Update()
    {
        GetComponent<Text>().text = "현재 시간 : " + DateTime.Now;
    }
}
