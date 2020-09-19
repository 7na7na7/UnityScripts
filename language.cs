using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class language : MonoBehaviour
{
    public string Eng, Kor, Jap,Chin;
    
    void Start()
    {
        SystemLanguage lang = Application.systemLanguage;
        switch (lang)
        {
            case SystemLanguage.Chinese:
                GetComponent<Text>().text = Chin;
                break;
            case SystemLanguage.ChineseSimplified:
                GetComponent<Text>().text = Chin;
                break;
            case SystemLanguage.ChineseTraditional:
                GetComponent<Text>().text = Chin;
                break;
            case SystemLanguage.Korean:
                GetComponent<Text>().text = Kor;
                break;
            case SystemLanguage.Japanese:
                GetComponent<Text>().text = Jap;
                break;
            default:
                GetComponent<Text>().text = Eng;
                break;
        }
    }
    
}
