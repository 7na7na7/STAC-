using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr instance;
    public AudioSource source;

    public AudioClip[] clips;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play(int index,float volume,float pitch)
    {
         Mathf.Clamp(volume,0f, 1f);
         source.pitch = pitch;
         source.PlayOneShot(clips[index],volume);
    }

/*
    #region 발표용
    private void Start()
    {
        GameObject.Find("BGM").GetComponent<AudioSource>().Pause();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().name == "Title")
            {
                if (GameObject.Find("BGM").GetComponent<AudioSource>().isPlaying)
                    GameObject.Find("BGM").GetComponent<AudioSource>().Pause();
                else
                    GameObject.Find("BGM").GetComponent<AudioSource>().UnPause();
            }
        }
    }
    #endregion
   */
}
