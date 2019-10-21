using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public IEnumerator attackanim()
    {
        bananagun gun = FindObjectOfType<bananagun>();
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isattack",true);
        yield return new WaitForSeconds(0.3f-gun.pitchctr*0.1f);
        anim.SetBool("isattack",false);
    }
}
