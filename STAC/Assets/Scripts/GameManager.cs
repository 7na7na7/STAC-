using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public float collision = 0.5f;
    public float delay = 0f;

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

        if (delay < collision)
            delay += Time.deltaTime;
        print(delay);
    }
}
