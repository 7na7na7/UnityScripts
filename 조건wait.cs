using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    yield return new WaitUntil(() => num1 < num2); //num1이 num2보다 작아질 때까지 기다림(num1이 num2보자 작아지는 순간 풀림)
    yield return new WaitWhile(() => num3 < num4); //num3이 num4보다 작은 동안 기다림(num1이 num2보다 커지는 순간 풀림)
}
