using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IWETC저장코드: MonoBehaviour
{
    string currentstage = "currentstage";
    static int stage;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        stage = PlayerPrefs.GetInt(currentstage, 1);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (SceneManager.GetActiveScene().name == "1st")
            {
                SceneManager.LoadScene("1st");
            }
            else if (SceneManager.GetActiveScene().name == "2nd")
            {
                SceneManager.LoadScene("2nd");
            }
            else if (SceneManager.GetActiveScene().name == "3rd")
            {
                SceneManager.LoadScene("3rd");
            }
            else if (SceneManager.GetActiveScene().name == "4th")
            {
                SceneManager.LoadScene("4th");
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (SceneManager.GetActiveScene().name == "1st")
            {
                stage = 1;

            }
            else if (SceneManager.GetActiveScene().name == "2nd")
            {
                stage = 2;

            }
            else if (SceneManager.GetActiveScene().name == "3rd")
            {
                stage = 3;

            }
            else if (SceneManager.GetActiveScene().name == "4th")
            {
                stage = 4;
            }
            PlayerPrefs.SetInt(currentstage, stage); //저장
        }
    }
    public void load()
    {
        if (stage == 1)
        {
            Debug.Log("1");
            SceneManager.LoadScene("1st");
        }
        if (stage == 2)
        {
            Debug.Log("2");
            SceneManager.LoadScene("2nd");
        }
        if (stage == 3)
        {
            Debug.Log("3");
            SceneManager.LoadScene("3rd");
        }
        if (stage == 4)
        {
            Debug.Log("4");
            SceneManager.LoadScene("4th");
        }
    }
}

