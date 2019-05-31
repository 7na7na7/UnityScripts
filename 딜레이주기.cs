using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 딜레이주기: MonoBehaviour
{
    public flot delay;
    IEnumerator delay()
    {
        yield return new WaitForSeconds(delay);
        //delay의 값만큼 딜레이를 준다.
    }
}
