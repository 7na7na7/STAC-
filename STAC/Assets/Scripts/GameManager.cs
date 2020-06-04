using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int scoreUpValue = 1000;
   

    private void Awake()
    {
        if (instance == null)
            instance=this;
    }

    void Start()
    {
        ScoreMgr.instance.GameStart();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Restart();
    }
}
