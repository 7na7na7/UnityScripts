using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tabManager : MonoBehaviour
{
    public GameObject[] Tab;
    public Image[] TabBtnImage;
    public Sprite[] IdleSprite, SelectSprite;
    
    void Start() => TabClick(0);

    public void TabClick(int n)
    {
        for (int i = 0; i < Tab.Length; i++)
        {
            Tab[i].SetActive(i==n);
            TabBtnImage[i].sprite = i == n ? SelectSprite[i] : IdleSprite[i];
        }
    }
}
