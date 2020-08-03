using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class color
{
    public Color color1, color2;
}
public class BulletData : MonoBehaviour
{
    public float brightness;
    public Material[] Themes;
    public GameObject[] Colors;
    public int currentColorIndex;
    public color[] colors;
    public static BulletData instance;
    public float playerAroundValue; //플레이어 방향으로 직선 이동하는 동그라미가 인식하는 부분
    public string currentColorKey = "currentColor";
    
    public int[] isLockArray;

    public string[] keys;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            currentColorIndex = PlayerPrefs.GetInt(currentColorKey, 0);


            for (int i = 0; i < keys.Length; i++)
            {
                if (i==0)
                {
                    isLockArray[i] = PlayerPrefs.GetInt(keys[i],1);
                }
                else
                {
                    isLockArray[i] = PlayerPrefs.GetInt(keys[i],0);
                }
               
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    public Color SetColor(int index)
    {
        if (index == 0)
            return colors[currentColorIndex].color1;
        else
            return colors[currentColorIndex].color2;
    }

    public void Unlock(int value)
    {
        for (int i = 0; i < isLockArray.Length; i++)
        {
            if(i==value) 
                isLockArray[i] = 1;
            PlayerPrefs.SetInt(keys[i],isLockArray[i]);
        }
    }

    public void Reset()
    {
        for (int i = 0; i < isLockArray.Length; i++)
        {
            isLockArray[i] = 0;
            if(i==0)
                isLockArray[i] = 1;
            PlayerPrefs.SetInt(keys[i],isLockArray[i]);
        }
    }
}
