﻿using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SceneManagement;

public class GooglePlayManager : MonoBehaviour
{
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
      }
      else
      {
         Destroy(gameObject);
      }
   }

   public void LogIn()
   {
      Social.localUser.Authenticate((bool success) =>
      {
         if(success) 
            GameObject.Find("a").GetComponent<Text>().text = Social.localUser.userName; 
      });
   }

   public void LogInOrLogOut()
   {
      if (Social.localUser.authenticated) // GPGS 로그인 되어 있는 경우
      {
         ((PlayGamesPlatform) Social.Active).SignOut(); //로그아웃
      }
      else // GPGS 로그인이 되어 있지 않은 경우
      {
         Social.localUser.Authenticate((bool Success) =>
         {
            GameObject.Find("aa").GetComponent<Text>().text = "ADSA";
            //로그인
         });
      }
   }

   public void LogOut()
   {
      ((PlayGamesPlatform) Social.Active).SignOut();
   }

   // 리더보드에 점수등록 후 보기
   public void OnShowLeaderBoard()
   {
      Social.ShowLeaderboardUI();
   }

   // 업적보기
   public void OnShowAchievement()
   {
      Social.ShowAchievementsUI();
   }

}