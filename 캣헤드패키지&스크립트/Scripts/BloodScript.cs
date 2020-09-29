using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{
    public float delay;
    void Start()
    {
        StartCoroutine(delete(delay));
    }

    IEnumerator delete(float delay)
    {
        yield return new WaitForSeconds(delay);
        float a = 1f;
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        Color color = spr.color;
        while (true)
        {
            color.a -= 0.1f;
            spr.color = color;
            yield return new WaitForSeconds(Time.deltaTime);
            if (color.a < 0.1f)
                break;
        }
        Destroy(gameObject);
    }
}
