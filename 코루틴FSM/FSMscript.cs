using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMscript : MonoBehaviour
{
    public enum State { Idle, Fly, Attack };
    public State state;

    public Animator anim;
    public SpriteRenderer spr;
    public List<Sprite> AllSprs;
    WaitForSeconds Delay01=new WaitForSeconds(0.1f);
    WaitForSeconds Delay05=new WaitForSeconds(0.5f);
    WaitForSeconds Delay1=new WaitForSeconds(1);
    private int characterIndex;
    List<Sprite> CurSprites = new List<Sprite>();
    private const int SIZE = 4;
    public void SetCharacter(int index)
    {
        characterIndex = index;
        CurSprites.Clear();
        for(int i=0;i<SIZE;i++) CurSprites.Add(AllSprs[4*characterIndex+i]);
    }
    
    IEnumerator Start()
    {
        while (true)
        {
            yield return StartCoroutine(state.ToString());
        }
    }

    IEnumerator Idle()
    {
        spr.sprite = CurSprites[0];
        yield return Delay05;
        spr.sprite = CurSprites[1];
        yield return Delay05;
    }
    IEnumerator Fly()
    {
        spr.sprite = CurSprites[2];
        yield return Delay01;
        spr.sprite = CurSprites[3];
        yield return Delay01;
    }
    IEnumerator Attack()
    {
        spr.sprite = CurSprites[0];
        anim.SetTrigger("attack");
        yield return Delay1;
        state = State.Idle;
    }
}
