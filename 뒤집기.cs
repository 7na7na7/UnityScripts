using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 뒤집기: MonoBehaviour
{
    void 뒤집기()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
