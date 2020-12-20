using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LINQ : MonoBehaviour
{
    void Start()
    {
        //from, in, where, orderby, select
        
        int[] nums = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var numQuery = from num in nums where (num%3) == 0 orderby num descending select num; //num을 nums에서 찾고, num이 3으로 나누어떨어지는 num의 값을 내림차순으로 정렬
        foreach(int num in numQuery) //결과 출력, 3의 배수만 쿼리에 들어가 나온다. 내림차순이므로 9 6 3출력.
            print(num +" ");          
        
        string[] names = new string[]{ "abc","peter", "Tistory", "Z","kim"};
        var nameQuery = (from name in names orderby name.Length, name descending select name).Reverse(); //name을 names에서 찾고, 전부 찾은 다음 길이 기준으로 내림차순으로 정렬한 다음 뒤집음(다시 오름차순)
        foreach(string name in nameQuery) // 결과 출력, 길이 기준으로 오름차순 정렬
            print(name);
    }
}
