using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class JsonExample : MonoBehaviour
{
    [System.Serializable]
    public class JTestClass
    {
        public int i;
        public float f;
        public bool b;

        public Vector3 v;
        public string str;
        public int[] iArray;
        public List<int> iList = new List<int>();
        
        public JTestClass(bool isSet, int _i, float _f, bool _b)
        {
            if (isSet)

            {
                i = _i;
                f = _f;
                b = _b;

                v = new Vector3(39.56f, 21.2f, 6.4f);
                str = "JSON Test String";
                iArray = new int[] { 1, 1, 3, 5, 8, 13, 21, 34, 55 };



                for (int idx = 0; idx < 5; idx++)
                {
                    iList.Add(2 * idx);
                }
            }
        }
        
        public void Print()
        {
            Debug.Log("i = " + i);
            Debug.Log("f = " + f);
            Debug.Log("b = " + b);

            Debug.Log("v = " + v);
            Debug.Log("str = " + str);

            for (int idx = 0; idx < iArray.Length; idx++)
            {
                Debug.Log(string.Format("iArray[{0}] = {1}", idx, iArray[idx]));
            }

            for (int idx = 0; idx < iList.Count; idx++)
            {
                Debug.Log(string.Format("iList[{0}] = {1}", idx, iList[idx]));
            }
        }
        
        public string ObjectToJson(object obj) //오브젝트를 자손으로
        {
            return JsonUtility.ToJson(obj);
        }

        public T JsonToOject<T>(string jsonData) //자손을 오브젝트로
        {
            return JsonUtility.FromJson<T>(jsonData);
        }
        
        public void CreateJsonFile(string createPath, string fileName, string jsonData) //자손파일 만들기
        {
            //creatPath에 fileName으로 만들기로 하기
            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
            byte[] data = Encoding.UTF8.GetBytes(jsonData);
            fileStream.Write(data, 0, data.Length);
            fileStream.Close();
        }
        public T LoadJsonFile<T>(string loadPath, string fileName) //자손파일을 데이터로 변환
        {
            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
            byte[] data = new byte[fileStream.Length];
            fileStream.Read(data, 0, data.Length);
            fileStream.Close();
            string jsonData = Encoding.UTF8.GetString(data);
            return JsonUtility.FromJson<T>(jsonData);
        }
    }

    private void Start()
    {
        JTestClass jtc = new JTestClass(true, 3, 0.5f, true);
        string jsonData = jtc.ObjectToJson(jtc);
        JTestClass jtc2 = new JTestClass(true, 102, 0.912f, false);
        string jsonData2 = jtc2.ObjectToJson(jtc2);
        jtc.CreateJsonFile(Application.dataPath+"/Save/", "JTestClass1", jsonData); //저장
        jtc.CreateJsonFile(Application.dataPath+"/Save/", "JTestClass2", jsonData2);
        var jtc3 = jtc2.LoadJsonFile<JTestClass>(Application.dataPath+"/Save/", "JTestClass1"); //불러오기
        jtc3.Print(); //불러온 객체의 Print()함수 실행
    }
}
