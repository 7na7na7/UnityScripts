using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVRead : MonoBehaviour
{
    public int exp = 0;
    void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("DataFile");

        for (var i = 0; i < data.Count; i++)
        {
            print("Index "+(i).ToString()+" : "+data[i]["exp"]+data[i]["grade"] +data[i]["text"]);
        }

        exp = (int) data[0]["exp"];
        print("exp : "+exp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
