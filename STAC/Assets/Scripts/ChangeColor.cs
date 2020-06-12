using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public int ColorIndex = 0;
    public GameObject lockImg;
    public void ColorChange(int value)
    {
        if (BulletData.instance.isLockArray[value] == 1)
        {
            BulletData.instance.currentColorIndex = value;
            PlayerPrefs.SetInt(BulletData.instance.currentColorKey,value);
        }
    }

    private void Update()
    {
        if (BulletData.instance.isLockArray[ColorIndex] == 0)
            lockImg.SetActive(true);
        else
            lockImg.SetActive(false);
    }
}
