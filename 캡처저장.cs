using UnityEngine;
using System; //DateTime사용
using System.IO; //파일시스템 사용'

public class 캡처저장 : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("캡처됨!");
            Capture();
        }
    }
void Capture()
    {
        string folderPath = Application.dataPath + "/ScreenShot"; //Assets/ScreenShot폴더에 저장
        string fileName = DateTime.Now.ToString("yyyy_MM_dd HH_mm_ss") + ".png";

        if (!Directory.Exists(folderPath)) //파이리경로 없으면 만듬
        {
            Directory.CreateDirectory(folderPath);
        }
        ScreenCapture.CaptureScreenshot(Path.Combine(folderPath, fileName));
    }
}
