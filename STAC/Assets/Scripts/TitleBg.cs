using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBg : MonoBehaviour
{
    Sprite[] Themes;

    private void Awake()
    {
        Themes = FindObjectOfType<BulletData>().Themes;
    }

    void Update()
    {
        if(GetComponent<SpriteRenderer>().sprite!=Themes[BulletData.instance.currentColorIndex])
        GetComponent<SpriteRenderer>().sprite =Themes[BulletData.instance.currentColorIndex];
    }
}
