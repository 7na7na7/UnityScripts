using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public bool canexit = true;
    public bool isexit = false;
    public GameObject exit;
    public Text kill, alive;
    public int zombiecount = 0;
    private int currentTime = 0;
    public Transform parent;
    private bool ismade;
    public GameObject panel;
    public Text text;
    private Level lv;
    void Start()
    {
        ismade = true;
        StartCoroutine(getTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (!ismade)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene("play");
            else if (Input.GetKeyDown(KeyCode.T))
                SceneManager.LoadScene("title");
        }
        lv = FindObjectOfType<Level>();
        Move1 player = GameObject.Find("player").GetComponent<Move1>();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isexit)
            {
                if (!player.isdead)
                {
                    if (canexit)
                    {
                        exit.gameObject.SetActive(true);
                        lv.canpause = false;
                        Time.timeScale = 0;
                        isexit = true;
                    }
                }
            }
            else
            {
                exitoff();
            }
        }

        //kill.text = "Killed Zombie : " + zombiecount;
        //alive.text = "Alived Time : " + currentTime;
        if (player.isdead)
        {
            if (ismade)
            {
                text.text = "Alive Time : " + currentTime+"       "+"Killed Zombie : " + zombiecount;
                Instantiate(panel, parent);
                Instantiate(text,parent);
                Time.timeScale = 0;
                ismade = false;
            }
        }
    }

    public void exitoff()
    {
        FindChild pause = FindObjectOfType<FindChild>();
        pause.pauseoff();
        exit.gameObject.SetActive(false);
        lv.canpause = true;
        Time.timeScale = 1;
        isexit = false;
    }

    public void exiton()
    {
        Application.Quit();
    }
    IEnumerator getTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            currentTime += 1;
        }
    }

    public void restart()
    {
        Time.timeScale = 1;
            SceneManager.LoadScene("play");
        }

    public void title()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("title");
    }
}
