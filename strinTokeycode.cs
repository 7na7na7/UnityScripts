using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strinTokeycode : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode),"K")))
        {
            print("AAAA");
        }
    }
}
