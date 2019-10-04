using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsenteces : MonoBehaviour
{
    public string[] sentences;
    private void OnMouseDown()
    {
        if(DialogueManager.instance.dialoguegroup.alpha==0) 
            DialogueManager.instance.Ondialogue(sentences);
    }
}
