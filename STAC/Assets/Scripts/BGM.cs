using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGM : MonoBehaviour
{
    private AudioSource source;
    public bool isGameOver = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isGameOver)
        {
            
        }
    }
}
