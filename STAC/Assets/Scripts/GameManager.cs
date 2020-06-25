using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int scoreUpValue = 1000;

    public bool canRevival = true;

    private void Awake()
    {
        if (instance == null)
            instance=this;
        Time.timeScale = 1;
    }

    void Start()
    {
        ScoreMgr.instance.GameStart();
        Bullet[] bullets = FindObjectsOfType<Bullet>();
        foreach (var bullet in bullets)
        {
            bullet.SetFalse();
        }

        goldCol[] golds = FindObjectsOfType<goldCol>();
        foreach (var gold in  golds)
        {
            gold.SetFalse();
        }
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
