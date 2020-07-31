using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGM : MonoBehaviour
{
    public static BGM instance;
    
    public float speed;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        instance = this;
        source.volume = SoundMgr.instance.savedBgm;
    }

    public void fadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(fadeOutCor());
    }

    IEnumerator fadeOutCor()
    {
        while (source.volume>0)
        {
            source.volume = Mathf.Lerp(source.volume, 0, speed);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    
    public void fadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(fadeInCor());
    }

    IEnumerator fadeInCor()
    {
        while (source.volume<1)
        {
            source.volume = Mathf.Lerp(source.volume, 1, speed);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
