using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFillAmount : Monster
{
    public SpriteRenderer spriteRenderer;
    public void SetFill(float amount)
    {
        spriteRenderer.material.SetFloat("_Cutoff", amount);
    }

}
