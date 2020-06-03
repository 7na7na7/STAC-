using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreMgr : MonoBehaviour
{
    public static ScoreMgr instance;
    private string highscoreKey = "highscore";
    
    public int highScore = 0;
    public int score = 0;
    public bool isHighScore = false;
    void Awake()
    {
        //싱글톤
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        highScore = PlayerPrefs.GetInt(highscoreKey, 0); //저장된 값 받아옴
        
    }

    public void ScoreUp(int v)
    {
        score += v;
    }

    public void GameStart() //게임 시작 시 초기화
    {
        score = 0;
        isHighScore = false;
    }
    
    public void AddScore(int v)
    {
        score += v;
        if (score > highScore) //최고점수 갱신
        {
            highScore = score;
            PlayerPrefs.SetInt(highscoreKey,highScore);
            isHighScore = true;
        }
    }
}
