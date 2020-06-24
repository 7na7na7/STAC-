using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject DieParticle;
    public static Player instance;
  
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Die()
    {
        Instantiate(DieParticle, transform.position, Quaternion.identity);
        CameraManager.instance.GameOver();
        CameraManager.instance.lastTr = gameObject.transform;
        Destroy(gameObject);
    }

   
}
