using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    private bool once = false;
    public AudioSource audiosource;
    public int realgold = 0;
    public int gold = 0;
    public static GoldManager instance;

    public string goldstring = "gold";
    public int savedgold = 0;

    void Awake()
    {
        audiosource.volume = 0;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        
        savedgold= PlayerPrefs.GetInt(goldstring, 0);
        if (SceneManager.GetActiveScene().name == "play")
        {
            if (!once)
            {
                once = true;
                audiosource.volume = 1;
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (audiosource.volume == 1)
                    audiosource.volume = 0;
                else
                    audiosource.volume = 1;
            }
        }
            
    }
}
