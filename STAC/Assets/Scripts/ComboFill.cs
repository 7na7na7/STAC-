using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboFill : MonoBehaviour
{
   public Image fill;
   private float currentTime = 1;
   public GameObject Text1,Text2;
   private void Update()
   {
       if (currentTime > 0)
       {
           currentTime -= Time.deltaTime;    
           Text1.SetActive(true);
           Text2.SetActive(true);
       }
       else
       {
           Text1.SetActive(false);
           Text2.SetActive(false);
       }
       fill.fillAmount = currentTime;
   }
}
