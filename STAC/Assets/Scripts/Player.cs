using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject pos;
    public GameObject Theme;
    public GameObject DieParticle;
    public static Player instance;
  
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Die()
    {
        pos.transform.SetParent(GameObject.Find("GameManager").transform);
        Theme.transform.SetParent(GameObject.Find("GameManager").transform);
        Instantiate(DieParticle, transform.position, Quaternion.identity);
        CameraManager.instance.GameOver();
        Destroy(gameObject);
    }

   
}
