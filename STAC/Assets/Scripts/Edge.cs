using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public int v_1;
    public bool isOne = false;

    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if (isOne) //변 하나의 색깔일 때
        {
            if (bullet.CompareTag("Color1")) //같은 색이라면
            {
                GameManager.instance.delay = 0f;
                ScoreMgr.instance.AddScore(v_1);
            }
            if(bullet.CompareTag("Color2")) //다른 색이라면
            {
                if(GameManager.instance.delay>=GameManager.instance.collision) 
                    Player.instance.Die();
            }
        }
        else //변 두 개의 색깔일 때
        {
            if (bullet.CompareTag("Color2")) //같은 색이라면
            {
                GameManager.instance.delay = 0f;
                ScoreMgr.instance.AddScore(v_1);
            }
            if(bullet.CompareTag("Color1"))//다른 색이라면
            {
                if(GameManager.instance.delay>=GameManager.instance.collision) 
                    Player.instance.Die();
            }
        }
        
    }
}
