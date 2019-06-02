using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 하이스코어저장: MonoBehaviour
{
    void Start()
    {
        score = 0;
    }
    public static int score = 0;
    public Text scoretext; //여기에 텍스트를 갓다넣는다
    public Text highScoreText; //여기도

    private string keyString = "highScore"; //하이스트링을 나타내는 문자열 선언
    private int savedScore = 0;

    void Awake()
    {
        savedScore = PlayerPrefs.GetInt(keyString, 0); //저장된 하이스코어 불러오기
        highScoreText.text = "HIGH SCORE : " + savedScore.ToString("000000");
    }
    private void Update()
    {
        scoretext.text = "SCORE : " + score.ToString("000000");
        if (score > savedScore)
        {
            PlayerPrefs.SetInt(keyString, score); //하이스코어 저장
        }
    }
}

