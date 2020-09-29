using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestroy : MonoBehaviour
{
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,delay);
        try
        {
            if (transform.GetChild(0).gameObject.name == "Explosion")
            {
                FindObjectOfType<GameManager>().flash();
                if(FindObjectOfType<GameManager>().isBig)
                    transform.localScale=new Vector3(transform.localScale.x+2,transform.localScale.y+2,transform.localScale.z);
                Destroy(transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>(), 0.3f);
            }
        }
        catch (Exception e)
        {
        }
       
    }

    IEnumerator delaydelete()
    {
        yield return new WaitForSeconds(0.5f);
        
    }
}
