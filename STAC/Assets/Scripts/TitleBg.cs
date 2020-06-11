using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBg : MonoBehaviour
{
    public Sprite[] Themes;
    void Update()
    {
        if(GetComponent<SpriteRenderer>().sprite!=Themes[BulletData.instance.currentColorIndex])
        GetComponent<SpriteRenderer>().sprite =Themes[BulletData.instance.currentColorIndex];
    }
}
