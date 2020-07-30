using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SceneManagement;

public class GooglePlayManager : MonoBehaviour
{
   public int canStage1 = 0;
   public int canStage2 = 0;
   public int canStage3 = 0;
   private string canStage1Key = "canStage1";
   private string canStage2Key = "canStage2";
   private string canStage3Key = "canStage3";
   public int isFirst = 0;
   public string isFirstKey = "isFirst";
   public static GooglePlayManager instance;
   private void Start()
   {
      if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject);
         PlayGamesPlatform.DebugLogEnabled = true;
         PlayGamesPlatform.Activate();
         LogIn();
         canStage1 = PlayerPrefs.GetInt(canStage1Key,0);
         canStage2 = PlayerPrefs.GetInt(canStage2Key,0);
         canStage3 = PlayerPrefs.GetInt(canStage3Key,0);
         isFirst = PlayerPrefs.GetInt(isFirstKey, 0);
         
         if (isFirst == 0)
         {
            FindObjectOfType<LoadScene>().Language();
         }
      }
      else
      {
         Destroy(gameObject);
      }
   }
   
   public void CanStage1()
   {
      if (canStage1 != 1)
      {
         canStage1 = 1;
         PlayerPrefs.SetInt(canStage1Key, 1);
      }
   }
   public void CanStage2()
   {
      if (canStage2 != 1)
      {
         canStage2 = 1;
         PlayerPrefs.SetInt(canStage2Key, 1);
      }
   }
   public void CanStage3()
   {
      if (canStage3 != 1)
      {
         canStage3 = 1;
         PlayerPrefs.SetInt(canStage3Key, 1);
      }
   }
   public void LogIn()
   {
      if (Social.localUser.authenticated)
      {
      }
      else
      {
         Social.localUser.Authenticate((bool success) =>
            { });  
      }
   }

   public void LogInOrLogOut()
   {
      if (Social.localUser.authenticated) // GPGS 로그인 되어 있는 경우
      {
         ((PlayGamesPlatform)Social.Active).SignOut(); //로그아웃
      }
      else // GPGS 로그인이 되어 있지 않은 경우
      {
         Social.localUser.Authenticate((bool Success) =>
         {
            //로그인
         });    
      }
   }
   public void LogOut()
   {
      ((PlayGamesPlatform)Social.Active).SignOut();
   }
   // 리더보드에 점수등록 후 보기
   public void OnShowLeaderBoard()
   {
      Social.ShowLeaderboardUI();
   }

   public void AddScore1(int score)
   {
      Social.ReportScore(score, GPGSIds.leaderboard______1, (bool bSuccess) =>
      {
      });
   }
   public void AddScore2(int score)
   {
      Social.ReportScore(score, GPGSIds.leaderboard______2, (bool bSuccess) =>
      {
      });
   }
   public void AddScore3(int score)
   {
      Social.ReportScore(score, GPGSIds.leaderboard______3, (bool bSuccess) =>
      {
      });
   }
   public void AddScore4(int score)
   {
      Social.ReportScore(score, GPGSIds.leaderboard______4, (bool bSuccess) =>
      {
      });
   }
   public void AddCombo1(int combo)
   {
      Social.ReportScore(combo, GPGSIds.leaderboard______1_2, (bool bSuccess) =>
      {
      });
   }
   public void AddCombo2(int combo)
   {
      Social.ReportScore(combo, GPGSIds.leaderboard______2_2, (bool bSuccess) =>
      {
      });
   }
   public void AddCombo4(int combo)
   {
      
      Social.ReportScore(combo, GPGSIds.leaderboard______4_2, (bool bSuccess) =>
      {
      });
      
   }
   // 업적보기
   public void OnShowAchievement()
   {
      Social.ShowAchievementsUI();
   }
 
   // 업적추가
   public void Achievement1()
   {
      Social.ReportProgress(GPGSIds.achievement__6, 100.0f, (bool bSuccess) => { }); //업적 달성!
   }
   public void Achievement2()
   {
      Social.ReportProgress(GPGSIds.achievement__12, 100.0f, (bool bSuccess) => { }); //업적 달성!
   }
   public void Achievement3()
   {
      Social.ReportProgress(GPGSIds.achievement__24, 100.0f, (bool bSuccess) => { }); //업적 달성!
   }
   public void Achievement4()
   {
      Social.ReportProgress(GPGSIds.achievement____1, 100.0f, (bool bSuccess) => { }); //업적 달성!
   }
   public void Achievement5()
   {
      Social.ReportProgress(GPGSIds.achievement____1_2, 100.0f, (bool bSuccess) => { }); //업적 달성!
   }
   public void Achievement6()
   {
      Social.ReportProgress(GPGSIds.achievement____1_3, 100.0f, (bool bSuccess) => { }); //업적 달성!
   }
   public void Achievement7()
   {
      Social.ReportProgress(GPGSIds.achievement____2, 100.0f, (bool bSuccess) => { }); //업적 달성!
   }
   public void Achievement8()
   {
      Social.ReportProgress(GPGSIds.achievement____2_2, 100.0f, (bool bSuccess) => { }); //업적 달성!
   }
   public void Achievement9()
   {
      Social.ReportProgress(GPGSIds.achievement____2_3, 100.0f, (bool bSuccess) => { }); //업적 달성!
   }
   public void ToTitle()
   {
      SceneManager.LoadScene("Title");
   }

   public void ToSetting()
   {
      SceneManager.LoadScene("Setting");
   }
}