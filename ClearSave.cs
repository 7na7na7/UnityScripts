using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSave : MonoBehaviour
{
    public static ClearSave instance;
    public string[] stageKeys;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.DeleteAll();
        }
        if(Input.GetKeyDown(KeyCode.F2))
        {
            for (int i = 0; i < stageKeys.Length; i++)
            {
                Clear(i);
            }
        }
    }

    public void Clear(int stageNum)
    {
        PlayerPrefs.SetInt(stageKeys[stageNum-1],1);
    }

    public int IsClear(int stageNum)
    {
        return PlayerPrefs.GetInt(stageKeys[stageNum - 1], 0);
    }
}
