using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Func : MonoBehaviour
{
    
    public void keySetting()
    {
        SceneManager.LoadScene("KeySetting");
    }
    public void youtuub()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=KA3KUaeyDbw");
    }

    public void title()
    {
        SceneManager.LoadScene("Title");
    }
}
