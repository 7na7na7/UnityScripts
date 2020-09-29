using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    public string key;

    public bool ischanging;
    // Update is called once per frame
    void Update()
    {
        switch (key)
        {
            case "up1":
                GetComponent<Text>().text = KeySetting.instance.up1.ToString();
                break;
            case "up2":
                GetComponent<Text>().text = KeySetting.instance.up2.ToString();
                break;
            case "down1":
                GetComponent<Text>().text = KeySetting.instance.down1.ToString();
                break;
            case "down2":
                GetComponent<Text>().text = KeySetting.instance.down2.ToString();
                break;
            case "right1":
                GetComponent<Text>().text = KeySetting.instance.right1.ToString();
                break;
            case "right2":
                GetComponent<Text>().text = KeySetting.instance.right2.ToString();
                break;
            case "left1":
                GetComponent<Text>().text = KeySetting.instance.left1.ToString();
                break;
            case "left2":
                GetComponent<Text>().text = KeySetting.instance.left2.ToString();
                break;
            case "shot1":
                GetComponent<Text>().text = KeySetting.instance.shot1.ToString();
                break;
            case "shot2":
                GetComponent<Text>().text = KeySetting.instance.shot2.ToString();
                break;
            case "dash1":
                GetComponent<Text>().text = KeySetting.instance.dash1.ToString();
                break;
            case "dash2":
                GetComponent<Text>().text = KeySetting.instance.dash2.ToString();
                break;
            case "change11":
                GetComponent<Text>().text = KeySetting.instance.change11.ToString();
                break;
            case "change12":
                GetComponent<Text>().text = KeySetting.instance.change12.ToString();
                break;
            case "change21":
                GetComponent<Text>().text = KeySetting.instance.change21.ToString();
                break;
            case "change22":
                GetComponent<Text>().text = KeySetting.instance.change22.ToString();
                break;
        }
       
        if (ischanging)
        {
            foreach (KeyCode kc in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kc))
                {
                    switch (key)
                    {
                        case "up1":
                            KeySetting.instance.up1 = kc;
                            PlayerPrefs.SetString("u1",kc.ToString());
                            ischanging = false;
                            break;
                        case "up2":
                            KeySetting.instance.up2= kc;
                            PlayerPrefs.SetString("u2",kc.ToString());
                            ischanging = false;
                            break;
                        case "down1":
                            KeySetting.instance.down1= kc;
                            PlayerPrefs.SetString("d1",kc.ToString());
                            ischanging = false;
                            break;
                        case "down2":
                            KeySetting.instance.down2= kc;
                            PlayerPrefs.SetString("d2",kc.ToString());
                            ischanging = false;
                            break;
                        case "right1":
                            KeySetting.instance.right1= kc;
                            PlayerPrefs.SetString("r1",kc.ToString());
                            ischanging = false;
                            break;
                        case "right2":
                            KeySetting.instance.right2= kc;
                            PlayerPrefs.SetString("r2",kc.ToString());
                            ischanging = false;
                            break;
                        case "left1":
                            KeySetting.instance.left1= kc;
                            PlayerPrefs.SetString("l1",kc.ToString());
                            ischanging = false;
                            break;
                        case "left2":
                            KeySetting.instance.left2= kc;
                            PlayerPrefs.SetString("l2",kc.ToString());
                            ischanging = false;
                            break;
                        case "shot1":
                            KeySetting.instance.shot1= kc;
                            PlayerPrefs.SetString("s1",kc.ToString());
                            ischanging = false;
                            break;
                        case "shot2":
                            KeySetting.instance.shot2= kc;
                            PlayerPrefs.SetString("s2",kc.ToString());
                            ischanging = false;
                            break;
                        case "dash1":
                            KeySetting.instance.dash1= kc;
                            PlayerPrefs.SetString("a1",kc.ToString());
                            ischanging = false;
                            break;
                        case "dash2":
                            KeySetting.instance.dash2= kc;
                            PlayerPrefs.SetString("a2",kc.ToString());
                            ischanging = false;
                            break;
                        case "change11":
                            KeySetting.instance.change11= kc;
                            PlayerPrefs.SetString("c11",kc.ToString());
                            ischanging = false;
                            break;
                        case "change12":
                            KeySetting.instance.change12= kc;
                            PlayerPrefs.SetString("c12",kc.ToString());
                            ischanging = false;
                            break;
                        case "change21":
                            KeySetting.instance.change21= kc;
                            PlayerPrefs.SetString("c21",kc.ToString());
                            ischanging = false;
                            break;
                        case "change22":
                            KeySetting.instance.change22= kc;
                            PlayerPrefs.SetString("c22",kc.ToString());
                            ischanging = false;
                            break;
                    }
                }
            }
        }
    }
    public void keyChange()
    {
        if (!ischanging)
        {
            StartCoroutine(change());
        }
    }

    IEnumerator change()
    {
        ischanging = true;
        GameObject.Find("Canvas").transform.GetChild(22).gameObject.SetActive(true);
        yield return new WaitUntil(()=>Input.anyKeyDown);
        GameObject.Find("Canvas").transform.GetChild(22).gameObject.SetActive(false);
        ischanging = false;
    }

    public void ResetKey()
    {
        PlayerPrefs.SetString("u1","W");
        PlayerPrefs.SetString("d1","S");
        PlayerPrefs.SetString("r1","D");
        PlayerPrefs.SetString("l1","A");
        PlayerPrefs.SetString("s1","R");
        PlayerPrefs.SetString("a1","T");
        PlayerPrefs.SetString("c11","F");
        PlayerPrefs.SetString("c12","G");
                
        PlayerPrefs.SetString("u2","UpArrow");
        PlayerPrefs.SetString("d2","DownArrow");
        PlayerPrefs.SetString("r2","RightArrow");
        PlayerPrefs.SetString("l2","LeftArrow");
        PlayerPrefs.SetString("s2","Keypad5");
        PlayerPrefs.SetString("a2","Keypad6");
        PlayerPrefs.SetString("c21","Keypad2");
        PlayerPrefs.SetString("c22","Keypad3");
        KeySetting.instance.sup1 = PlayerPrefs.GetString("u1");
        KeySetting.instance.up1 = (KeyCode) System.Enum.Parse(typeof(KeyCode),KeySetting.instance. sup1);
        KeySetting.instance. sdown1 = PlayerPrefs.GetString("d1");
        KeySetting.instance.  down1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), KeySetting.instance.sdown1);
        KeySetting.instance.  sright1 = PlayerPrefs.GetString("r1");
        KeySetting.instance.  right1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), KeySetting.instance.sright1);
        KeySetting.instance.  sleft1 = PlayerPrefs.GetString("l1");
        KeySetting.instance.  left1 = (KeyCode) System.Enum.Parse(typeof(KeyCode),KeySetting.instance. sleft1);
        KeySetting.instance. sshot1 = PlayerPrefs.GetString("s1");
        KeySetting.instance. shot1 = (KeyCode) System.Enum.Parse(typeof(KeyCode),KeySetting.instance.sshot1);
        KeySetting.instance.  sdash1 = PlayerPrefs.GetString("a1");
        KeySetting.instance.dash1 = (KeyCode) System.Enum.Parse(typeof(KeyCode),KeySetting.instance. sdash1);
        KeySetting.instance.schange11 = PlayerPrefs.GetString("c11");
        KeySetting.instance.change11 = (KeyCode) System.Enum.Parse(typeof(KeyCode), KeySetting.instance.schange11);
        KeySetting.instance.schange12 = PlayerPrefs.GetString("c12");
        KeySetting.instance.change12 = (KeyCode) System.Enum.Parse(typeof(KeyCode), KeySetting.instance.schange12);
            
        KeySetting.instance.sup2 = PlayerPrefs.GetString("u2");
        KeySetting.instance.up2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), KeySetting.instance.sup2);
        KeySetting.instance.sdown2 = PlayerPrefs.GetString("d2");
        KeySetting.instance. down2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), KeySetting.instance.sdown2);
        KeySetting.instance.sright2 = PlayerPrefs.GetString("r2");
        KeySetting.instance. right2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), KeySetting.instance.sright2);
        KeySetting.instance. sleft2 = PlayerPrefs.GetString("l2");
        KeySetting.instance. left2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), KeySetting.instance.sleft2);
        KeySetting.instance.  sshot2 = PlayerPrefs.GetString("s2");
        KeySetting.instance. shot2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), KeySetting.instance.sshot2);
        KeySetting.instance. sdash2 = PlayerPrefs.GetString("a2");
        KeySetting.instance. dash2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), KeySetting.instance.sdash2);
        KeySetting.instance. schange21 = PlayerPrefs.GetString("c21");
        KeySetting.instance. change21 = (KeyCode) System.Enum.Parse(typeof(KeyCode), KeySetting.instance.schange21);
        KeySetting.instance. schange22 = PlayerPrefs.GetString("c22");
        KeySetting.instance. change22 = (KeyCode) System.Enum.Parse(typeof(KeyCode),KeySetting.instance. schange22);
    }
}
