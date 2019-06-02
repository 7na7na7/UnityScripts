using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 충돌처리: MonoBehaviour
{
    void OnCollisionEnter(Collision other)// 충돌했을시 발동한다.
    {
        SceneManager.LoadScene("play");
        if (other.gameObject.tag == ("score"))
        {
            score += 100;
            Debug.Log("asf");
        }
        else if (other.gameObject.tag == ("wall"))
        {
            SceneManager.LoadScene("play");
        }
    }
    void OnTriggerEnter(Collider col) //2D는 OnTriggerEnter2D로 해야한다.  trigger처리시 발동한다.
    {
        if (col.gameObject.tag == ("score")) //태그가 score인 녀석
            score += 100;
    }
}

