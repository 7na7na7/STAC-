using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorPick : MonoBehaviour
{
    public Sprite[] colors;
    public GameObject[] pickers;
    private int index = 0;
    void Start()
    {
       
    }


    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            pickers[i].GetComponent<SpriteRenderer>().sprite = colors[index + i];
        }
    }

    public void leftRotate()
    {
        if(index!=0) 
            index--;
    }

    public void rightRotate()
    {
        if(index!=colors.Length-4) 
            index++;
    }
}
