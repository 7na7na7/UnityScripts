using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMove : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("play");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void highscore()
    {
        SceneManager.LoadScene("highscore");
    }

    public void title()
    {
        SceneManager.LoadScene("title");
    }
}
