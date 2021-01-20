using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 피벗구하기 : MonoBehaviour
{
    private void Start()
    {
        print(transform.position+" "+GetComponent<SpriteRenderer>().bounds.center);
    }
}
