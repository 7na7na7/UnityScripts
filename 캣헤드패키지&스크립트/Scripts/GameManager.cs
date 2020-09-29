using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isPause = false;
    public AudioSource audio;
    public AudioClip koung;

    public GameObject pausedPanel;
    public GameObject popUp;
    private Transform CanvasTr;
    public bool isGameOver = false;
    public GameObject GameOverpanel;
    public GameObject p1, p2;
    public bool p1Dead = false;
    public bool p2Dead = false;
    public float spawnDelay;
    
    public Text wave_left;
    public int[] zombiecount;

    public int currentzombie = 0;
    public int i = 0; //for문용 변수
    public int wave = 0;
    private bool waveClear = false;
    private bool isonce = true;
    public bool GrenadeUp = false;
    public GameObject flashPanel;
    public bool isBig = false;
    public int wallHard = 50;
    public GameObject clear;
    private void Awake()
    {
        StartCoroutine(spawn());
        StartCoroutine(PopUPCor());
        CanvasTr = GameObject.Find("Canvas").GetComponent<Transform>();
        //currentzombie--;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "double")
        {
            if (p1Dead && p2Dead)
            {
                if (!isGameOver)
                {
                    StopAllCoroutines();
                    isGameOver = true;
                    Time.timeScale = 0;
                    GameOverpanel.SetActive(true);
                }
            }
        }
        else
        {
            if (p1Dead)
            {
                if (!isGameOver)
                {
                    StopAllCoroutines();
                    isGameOver = true;
                    Time.timeScale = 0;
                    GameOverpanel.SetActive(true);
                }
            }
        }

        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                FindObjectOfType<KeySetting>().currentScore = 0;
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Title");
            }
        }
        else
        {
            if (!waveClear)
                wave_left.text = wave + " Wave - " + currentzombie + " Left";
            else
                wave_left.text = "  Wave Clear!";

            if (Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown(KeyCode.Escape))

    {
                if (Time.timeScale != 0)
                {
                    Time.timeScale = 0;
                    pausedPanel.SetActive(true);
                    isPause = true;
                }
                else
                {
                    Time.timeScale = 1;
                    pausedPanel.SetActive(false);
                    isPause = false;
                }
            }

            if (isPause)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    FindObjectOfType<KeySetting>().currentScore = 0;
                }

                if (Input.GetKeyDown(KeyCode.T))
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Title");
                }
            }
            
        }

        if (wave >= 9)
        {
            if (!GrenadeUp)
                GrenadeUp = true;
        }
    }

    public void Dead1()
    {
        StartCoroutine(spawnP1());
    }

    public void Dead2()
    {
        StartCoroutine(spawnP2());
    }
    IEnumerator spawnP1()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(p1, transform.position,Quaternion.identity);
        p1Dead = false;
    }
    IEnumerator spawnP2()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(p2, transform.position,Quaternion.identity);
        p2Dead = false;
    }



    IEnumerator spawn()
    {
        yield return new WaitForSeconds(5f);
        wave++;
        audio.PlayOneShot(koung,0.5f);
        for (i = 0; i < zombiecount.Length; i++) //끝나고 i++
        {
            yield return new WaitUntil(() => zombiecount[i] <= 0); //zombiecount[i]가 0이 될 때까지 기다림(현재 웨이브의 좀비가 다 죽을 때까지)
            waveClear = true;
            yield return new WaitForSeconds(5f); //기다림...
            if (wave == 20)
            {
                clear.SetActive(true);
                isGameOver = true;
                Time.timeScale = 0;
            }
            wave++;
            audio.PlayOneShot(koung,1f);
            yield return new WaitForSeconds(5f); //기다림...
            waveClear = false;
            currentzombie = 0; //현재좀비수 초기화
            FindObjectOfType<KeySetting>().currentScore += 1000*wave;
            Time.timeScale += 0.03f;
        }
    }
    
    public void zombieDead(int point)
    {
        currentzombie--;
        zombiecount[i]--;
        FindObjectOfType<KeySetting>().currentScore += point;
    }
    public void zombieCreate()
    {
        currentzombie++;
    }

    IEnumerator PopUPCor()
    {
        int i = 1;
        while (true)
        {
            yield return new WaitUntil(()=>wave==i);
            i++;
            GameObject pop7 =Instantiate(popUp, CanvasTr);
            pop7.GetComponent<Text>().text = "-Wave "+(i-1)+"-";
            if (wave == 2)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop2 =Instantiate(popUp, CanvasTr);
                pop2.GetComponent<Text>().text = "new weapon : uzi";
            }
            else if (wave == 3)
            {
                yield return new WaitForSeconds(1f);
                GameObject popa11 =Instantiate(popUp, CanvasTr);
                popa11.GetComponent<Text>().text = "pistol : rapid fire";
            }
            else if (wave == 4)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop11 =Instantiate(popUp, CanvasTr);
                pop11.GetComponent<Text>().text = "new weapon : ShotGun";
            }
            else if (wave == 5)
            {
                yield return new WaitForSeconds(1f);
                GameObject popa1a1 =Instantiate(popUp, CanvasTr);
                popa1a1.GetComponent<Text>().text = "uzi : rapid fire";
            }
            else if (wave == 6)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop4 =Instantiate(popUp, CanvasTr);
                pop4.GetComponent<Text>().text = "new weapon : grenade";
            }
            else if (wave == 7)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop4a =Instantiate(popUp, CanvasTr);
                pop4a.GetComponent<Text>().text = "shotgun : rapid fire";
            }
            else if (wave == 8)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop4a =Instantiate(popUp, CanvasTr);
                pop4a.GetComponent<Text>().text = "new weapon : container";
                yield return new WaitForSeconds(1f);
                GameObject pop4aa =Instantiate(popUp, CanvasTr);
                pop4aa.GetComponent<Text>().text = "uzi : double ammo";
            }
            else if (wave == 9)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop4a =Instantiate(popUp, CanvasTr);
                pop4a.GetComponent<Text>().text = "shotgun : double ammo";
            }
            else if (wave == 10)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop4a =Instantiate(popUp, CanvasTr);
                pop4a.GetComponent<Text>().text = "new weapon : wall";
                yield return new WaitForSeconds(1f);
                GameObject popz4a =Instantiate(popUp, CanvasTr);
                popz4a.GetComponent<Text>().text = "grenade : fourth explosion";
            }
            else if (wave == 11)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop4a =Instantiate(popUp, CanvasTr);
                pop4a.GetComponent<Text>().text = "container : double ammo";
            }
            else if (wave == 12)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop111a =Instantiate(popUp, CanvasTr);
                pop111a.GetComponent<Text>().text = "new weapon : mine";
                yield return new WaitForSeconds(1f);
                GameObject pop5a =Instantiate(popUp, CanvasTr);
                pop5a.GetComponent<Text>().text = "wall : double ammo";
            }
            else if (wave == 13)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop4a =Instantiate(popUp, CanvasTr);
                pop4a.GetComponent<Text>().text = "uzi/shotgun : rapid fire, double ammo";
            }
            else if (wave == 14)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop4a =Instantiate(popUp, CanvasTr);
                pop4a.GetComponent<Text>().text = "mine : double ammo";
            }
            else if (wave == 15)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop4a =Instantiate(popUp, CanvasTr);
                pop4a.GetComponent<Text>().text = "new weapon : missile";
            }
            else if (wave == 16)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop4a =Instantiate(popUp, CanvasTr);
                pop4a.GetComponent<Text>().text = "wall : more harder";
                wallHard += 20;
            }
            else if (wave == 17)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop4a =Instantiate(popUp, CanvasTr);
                pop4a.GetComponent<Text>().text = "rocket : double ammo";
            }
            else if (wave == 18)
            {
                yield return new WaitForSeconds(1f);
                GameObject pop4a =Instantiate(popUp, CanvasTr);
                pop4a.GetComponent<Text>().text = "rocket : rapid fire";
            }
            else if (wave == 19)
            {
                isBig = true;
                yield return new WaitForSeconds(1f);
                GameObject posp4a =Instantiate(popUp, CanvasTr);
                posp4a.GetComponent<Text>().text = "explosion : big bang";
            }
            else if (wave == 20)
            {
                isBig = true;
                yield return new WaitForSeconds(1f);
                GameObject posp4a =Instantiate(popUp, CanvasTr);
                posp4a.GetComponent<Text>().text = "last stage - boss party";
            }
        }
    }

    public void flash()
    {
        Color color = flashPanel.GetComponent<Image>().color;
        color.a = 0.8f;
        flashPanel.GetComponent<Image>().color = color;
    }
}
