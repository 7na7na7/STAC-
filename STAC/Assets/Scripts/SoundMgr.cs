using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Play(int index,float volume)
    {
         Mathf.Clamp(volume,0f, 1f);
         source.PlayOneShot(clips[index],volume);
    }
}
