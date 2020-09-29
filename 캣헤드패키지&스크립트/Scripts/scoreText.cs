using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{
    public bool a = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!a)
            GetComponent<Text>().text = FindObjectOfType<KeySetting>().currentScore.ToString("00000000");
        else
            GetComponent<Text>().text = "Your Score : " + FindObjectOfType<KeySetting>().currentScore.ToString();
    }
}
