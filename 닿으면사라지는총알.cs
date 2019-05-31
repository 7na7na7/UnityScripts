using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 닿으면사라지는총알: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(this.gameObject);
    }
}
