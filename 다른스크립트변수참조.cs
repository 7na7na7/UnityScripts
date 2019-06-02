using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 다른스크립트변수참조: MonoBehaviour
{
    //savescore이라는 스크립트에 public string easyscore = "easyscore"; 을 선언해놓았을 때,
    void Start()
    {
        scoresave sc = GameObject.Find("saveobj").GetComponent<scoresave>(); //참조
        Debug.Log(sc.easyscore); //결과: easyscore
    }
}

