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
    public int currentColorIndex;
    public color[] colors;
    public static BulletData instance;
    public float playerAroundValue; //플레이어 방향으로 직선 이동하는 동그라미가 인식하는 부분
    public string currentColorKey = "currentColor";
    
    public int[] isLockArray;
    
    private string key1 = "color1";
    private string key2 = "color2";
    private string key3 = "color3";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            currentColorIndex = PlayerPrefs.GetInt(currentColorKey, 0);
            
            isLockArray[0] = PlayerPrefs.GetInt(key1,1);
            isLockArray[1] = PlayerPrefs.GetInt(key2, 0);
            isLockArray[2] = PlayerPrefs.GetInt(key3, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //스페이스바 누르면 모든 테마 언락
        {
            PlayerPrefs.SetInt(key2,1);
            PlayerPrefs.SetInt(key3,1);
            isLockArray[1] = 1;
            isLockArray[2] = 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt)) //알트키 누르면 설정초기화
        {
            PlayerPrefs.SetInt(key2,0);
            isLockArray[1] = 0;
            PlayerPrefs.SetInt(key3,0);
            isLockArray[2] = 0;
        }
    }

    public Color SetColor(int index)
    {
        if (index == 0)
            return colors[currentColorIndex].color1;
        else
            return colors[currentColorIndex].color2;
    }
}
