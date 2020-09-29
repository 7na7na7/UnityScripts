using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySetting : MonoBehaviour
{
    public string firstkey = "first";
    public string hightscorekey = "highscore";
    public int highScore = 0;
    public int currentScore = 0;
    public string sup1, 
        sup2,
        sdown1,
        sdown2,
        sright1,
        sright2,
        sleft1,
        sleft2,
        sshot1,
        sshot2,
        sdash1,
        sdash2,
        schange11,
        schange12,
        schange21,
        schange22;
    public static KeySetting instance;
    public KeyCode up1,
        up2,
        down1,
        down2,
        right1,
        right2,
        left1,
        left2,
        shot1,
        shot2,
        dash1,
        dash2,
        change11,
        change12,
        change21,
        change22;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
            if (PlayerPrefs.GetInt(firstkey) != 5)
            {
                PlayerPrefs.SetInt(firstkey,5);
                PlayerPrefs.SetString("u1","W");
                PlayerPrefs.SetString("d1","S");
                PlayerPrefs.SetString("r1","D");
                PlayerPrefs.SetString("l1","A");
                PlayerPrefs.SetString("s1","R");
                PlayerPrefs.SetString("a1","T");
                PlayerPrefs.SetString("c11","F");
                PlayerPrefs.SetString("c12","G");
                
                PlayerPrefs.SetString("u2","UpArrow");
                PlayerPrefs.SetString("d2","DownArrow");
                PlayerPrefs.SetString("r2","RightArrow");
                PlayerPrefs.SetString("l2","LeftArrow");
                PlayerPrefs.SetString("s2","Keypad5");
                PlayerPrefs.SetString("a2","Keypad6");
                PlayerPrefs.SetString("c21","Keypad2");
                PlayerPrefs.SetString("c22","Keypad3");
                highScore = 0;
            }


            sup1 = PlayerPrefs.GetString("u1");
            up1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), sup1);
            sdown1 = PlayerPrefs.GetString("d1");
            down1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), sdown1);
            sright1 = PlayerPrefs.GetString("r1");
            right1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), sright1);
            sleft1 = PlayerPrefs.GetString("l1");
            left1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), sleft1);
            sshot1 = PlayerPrefs.GetString("s1");
            shot1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), sshot1);
            sdash1 = PlayerPrefs.GetString("a1");
            dash1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), sdash1);
            schange11 = PlayerPrefs.GetString("c11");
            change11 = (KeyCode) System.Enum.Parse(typeof(KeyCode), schange11);
            schange12 = PlayerPrefs.GetString("c12");
            change12 = (KeyCode) System.Enum.Parse(typeof(KeyCode), schange12);
            
            sup2 = PlayerPrefs.GetString("u2");
            up2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), sup2);
            sdown2 = PlayerPrefs.GetString("d2");
            down2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), sdown2);
            sright2 = PlayerPrefs.GetString("r2");
            right2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), sright2);
            sleft2 = PlayerPrefs.GetString("l2");
            left2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), sleft2);
            sshot2 = PlayerPrefs.GetString("s2");
            shot2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), sshot2);
            sdash2 = PlayerPrefs.GetString("a2");
            dash2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), sdash2);
            schange21 = PlayerPrefs.GetString("c21");
            change21 = (KeyCode) System.Enum.Parse(typeof(KeyCode), schange21);
            schange22 = PlayerPrefs.GetString("c22");
            change22 = (KeyCode) System.Enum.Parse(typeof(KeyCode), schange22);

            highScore=PlayerPrefs.GetInt(hightscorekey, 0);
        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (currentScore > highScore)
            highScore = currentScore;
        PlayerPrefs.SetInt(hightscorekey,highScore);
    }
}
