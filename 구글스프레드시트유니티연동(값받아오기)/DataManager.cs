using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Newtonsoft.Json;
using UnityEngine;
using Google.Apis.Sheets.v4.Data;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;

    public static DataManager I
    {
        get
        {
            if (_instance == null)
            {
                GameObject dataManager = new GameObject();
                dataManager.name = "DataManager";
                _instance = dataManager.AddComponent<DataManager>();
            }

            return _instance;
        }
    }

    // 테이블 묶음을 관리할 DataSet 변수
    private DataSet _database;

    private void Awake()
    {
        DontDestroyOnLoad(this); //객체 없어지지 않게 함
        InitDataManager();
    }

    public void InitDataManager()
    {
        _database = new DataSet("Database");
#if UNITY_EDITOR
        //에디터에서 실행시 스프레드시트 API 호출
        MakeSheetDatset(_database);
#else
	//Android, Ios 환경에서 실행 시 로컬 json 파일에서 데이터 받아옴
        LoadJsonData(_database);
#endif
    }

    public static class DataUtil //데이터를 용도에 맞게 발라내는 기능들을 모은 DataUtil클래스
    {
        public static DataTable GetDataTable(string fileName, string tableName) //데이터 테이블 구하기(파일이름, 테이블이름)
        {
            var obj = Resources.Load(fileName);
            string value = (obj as TextAsset).ToString();
            DataTable data = JsonConvert.DeserializeObject<DataTable>(value);
            data.TableName = tableName;

            return data;
        }

        public static DataTable GetDataTable(FileInfo info) //데이터 테이블 구하기(FileInfo)
        {
            string fileName = Path.GetFileNameWithoutExtension(info.Name);
            string path = string.Concat("JsonData/", fileName);
            string value = string.Empty;
            try
            {
                value = (Resources.Load(path) as TextAsset).ToString();
            }
            catch (NullReferenceException ex)
            {

            }

            DataTable data = JsonConvert.DeserializeObject<DataTable>(value);
            data.TableName = fileName;

            return data;
        }

        public static string GetDataValue(DataSet dataSet, string tableName, string primary, string value, string column) //경로를 주면 데이터를 받아옴
        {
            DataRow[] rows = dataSet.Tables[tableName].Select(string.Concat(primary, " = '", value, "'"));
            
            return rows[0][column].ToString();
        }

        public static void SetObjectFile<T>(string key, T data)
        {
            string value = JsonConvert.SerializeObject(data);
            File.WriteAllText(Application.dataPath + "/Resources/JsonData/" + key + ".json", value);
        }
    }
    private void MakeSheetDatset(DataSet dataset)
    {
        var pass = new ClientSecrets();
        pass.ClientId = "800426931082-c16nbgqvpb7ai74lrg78a5jqt4toke6a.apps.googleusercontent.com"; //QAuth 2.0 클라이언트 ID
        pass.ClientSecret = "ovQag2ur_mS_Ha4CLtOGNnJM"; //QAuth 2.0 클라이언트 PW

        var scopes = new string[] { SheetsService.Scope.SpreadsheetsReadonly };
        var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(pass, scopes, "spreadsheet", CancellationToken.None).Result;

        var service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "spreadsheet"
        });
        
        var request = service.Spreadsheets.Get("1arwNem7H7YEwZWcqEw1fqHg4jl1vAmIY0QFzc4e1X1E").Execute(); //스프레드시트 URL에서 따옴
		
        foreach(Sheet sheet in request.Sheets)
        {
            DataTable table = SendRequest(service, sheet.Properties.Title);
            dataset.Tables.Add(table);
        }
    }
    private DataTable SendRequest(SheetsService service, string sheetName) //스프레드시트 파일에 존재하는 시트들의 목록을 받아와서 시트별로 데이터를 받아옴
    {
        DataTable result = null;
        bool success = true;

        try
        {
            //!A1:M은 스프레드시트 A열부터 M열까지 데이터를 받아오겠다는 소리
            var request = service.Spreadsheets.Values.Get("1arwNem7H7YEwZWcqEw1fqHg4jl1vAmIY0QFzc4e1X1E", sheetName + "!A1:M");//스프레드시트 URL에서 따옴
            //API 호출로 받아온 IList 데이터
            var jsonObject = request.Execute().Values;
            //IList 데이터를 jsonConvert 하기위해 직렬화
            string jsonString = ParseSheetData(jsonObject);
            //DataTable로 변환
            result = SpreadSheetToDataTable(jsonString);
        }
        catch (Exception e)
        {
            success = false;
            Debug.LogError(e);
            string path = string.Format("JsonData/{0}", sheetName);
            //예외 발생시 로컬 경로에 있는 json 파일을 통해 데이터 가져옴
            result = DataUtil.GetDataTable(path, sheetName);
            Debug.Log("시트 로드 실패로 로컬 " + sheetName + " json 데이터 불러옴");
        }

        Debug.Log(sheetName + " 스프레드시트 로드 " + (success ? "성공" : "실패"));

        result.TableName = sheetName;

        if (result != null)
        {
            //변환한 테이블을 json 파일로 저장
            SaveDataToFile(result);
        }

        for (int i = 0; i < result.Rows.Count; i++)
        {
            print("-"+((int)i+1).ToString()+"번째 열-");
            for (int j = 0; j < result.Columns.Count; j++)
            {
                print(result.Rows[i][j]);
            }
          
        }
        return result;
    }
    private DataTable SpreadSheetToDataTable(string json) //json데이터를 데이터테이블 형식으로 변환
    {
        DataTable data = JsonConvert.DeserializeObject<DataTable>(json);
        return data;
    }
    
    private string ParseSheetData(IList<IList<object>> value) //시트 데이터를 json형식 string으로 변환
    {
        StringBuilder jsonBuilder = new StringBuilder();

        IList<object> columns = value[0];

        jsonBuilder.Append("[");
        for (int row = 1; row < value.Count; row++)
        {
            var data = value[row];
            jsonBuilder.Append("{");
            for (int col = 0; col < data.Count; col++)
            {
                jsonBuilder.Append("\"" + columns[col] + "\"" + ":");
                jsonBuilder.Append("\"" + data[col] + "\"");
                jsonBuilder.Append(",");
            }
            jsonBuilder.Append("}");
            if(row != value.Count - 1)
                jsonBuilder.Append(",");
        }
        jsonBuilder.Append("]");
        return jsonBuilder.ToString();
    }
    
    private void SaveDataToFile(DataTable newTable) //데이터 파일로 저장
    {
        //로컬경로
        string JsonPath = string.Concat(Application.dataPath + "/Resources/JsonData/" + newTable.TableName + ".json");
        FileInfo info = new FileInfo(JsonPath);
        //동일 파일 유무 체크
        if(info.Exists)
        {
            DataTable checkTable = DataUtil.GetDataTable(info);
            //파일 내용 체크
            if (BinaryCheck<DataTable>(newTable, checkTable))
            {
                return;
            }
        }
        //json파일 저장
        DataUtil.SetObjectFile(newTable.TableName, newTable);
    }
    private bool BinaryCheck<T>(T src, T target) //두 데이터 비교
    {
        //두 대상을 바이너리로 변환해서 비교, 다르면 false 반환
        BinaryFormatter formatter1 = new BinaryFormatter();
        MemoryStream stream1 = new MemoryStream();
        formatter1.Serialize(stream1, src);

        BinaryFormatter formatter2 = new BinaryFormatter();
        MemoryStream stream2 = new MemoryStream();
        formatter2.Serialize(stream2, target);

        byte[] srcByte = stream1.ToArray();
        byte[] tarByte = stream2.ToArray();

        if (srcByte.Length != tarByte.Length)
        {
            return false;
        }
        for (int i = 0; i < srcByte.Length; i++)
        {
            if (srcByte[i] != tarByte[i])
                return false;
        }
        return true;
    }
    
    private void LoadJsonData(DataSet dataset) 
    {
    	
        string JsonPath = string.Concat(Application.dataPath + "/Resources/JsonData/");
        DirectoryInfo info = new DirectoryInfo(JsonPath);
        foreach(FileInfo file in info.GetFiles())
        {
            //로컬 경로에서 json 가져와서 DataTable으로 변환
            DataTable table = DataUtil.GetDataTable(file);
            dataset.Tables.Add(table);
        }
    }
    
    public string SelectTableData(string tableName, string primary, string column)
    {
        DataRow[] rows = _database.Tables[tableName].Select(string.Concat(primary, " = '", column, "'"));

        return rows[0][column].ToString();
    }
}