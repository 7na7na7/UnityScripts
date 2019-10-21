using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour
{
    public Text kill, wave,goldtext;
    // Start is called before the first frame update
    void Start()
    {
        GoldManager gold = FindObjectOfType<GoldManager>();
        goldtext.text = gold.savedgold + " " + "Gold";
        save save = FindObjectOfType<save>();
        kill.text = save.highkill.ToString();
        wave.text = save.highwave.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
