using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class save : MonoBehaviour
{
    public bool isbgm = true;
    public static save instance;
    
    public static int highwave = 1;
    public static int highkill = 0;


    private string wavestring = "highwave",killstring="highkill"; //하이스트링을 나타내는 문자열 선언
    public int savedwave = 1,savedkill=0;

    void Awake()
    {
        Time.timeScale = 1;
        //PlayerPrefs.DeleteAll();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
        highwave= PlayerPrefs.GetInt(wavestring, 1); 
        highkill= PlayerPrefs.GetInt(killstring, 0);
    }

    private void Update()
    {
        if ( savedwave> highwave) //하이웨이브
        {
            PlayerPrefs.SetInt(wavestring, savedwave); 
        }
        if ( savedkill> highkill)//하이킬
        {
            PlayerPrefs.SetInt(killstring, savedkill); 
        }
    }
}
