using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie3col : MonoBehaviour
{
    private GameObject parent;
    private GameObject col;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("스피드증가발동!");
                parent = transform.parent.gameObject;
                parent.GetComponent<zombie3move>().speed =
                    parent.GetComponent<zombie3move>().speedup;
                this.gameObject.SetActive(false);
        }
    }
}
