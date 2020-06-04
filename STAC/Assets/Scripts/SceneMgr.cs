using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public void ChangeScene(string SceneName)
    {
        if (SceneName == "this")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            SceneManager.LoadScene(SceneName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Title")
            {
                Application.Quit();
            }
            else if (SceneManager.GetActiveScene().name == "Shop" || SceneManager.GetActiveScene().name == "Select")
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
