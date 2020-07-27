using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bpm노트출력 : MonoBehaviour
{
    public int bpm = 0;
    private double currentTime = 0d;
    
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm)
        {
            print("노트출력! "+Time.time);
            currentTime -= 60d / bpm;
        }
    }
}
