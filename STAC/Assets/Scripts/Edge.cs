using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public bool isOne = false;

    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if (isOne) //변 하나의 색깔일 때
        {
            if (bullet.CompareTag("Color1")) //같은 색이라면
            {

            }
            else if(bullet.CompareTag("Color2")) //다른 색이라면
            {
                Player.instance.Die();
            }
        }
        else //변 두 개의 색깔일 때
        {
            if (bullet.CompareTag("Color2")) //같은 색이라면
            {
              
            }
            else if(bullet.CompareTag("Color1"))//다른 색이라면
            {
                Player.instance.Die();
            }
        }
        
    }
}
