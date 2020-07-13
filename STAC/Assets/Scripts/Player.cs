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
        instance = this;
            transform.eulerAngles=new Vector3(0,0,30);
    }

    private void Start()
    {
        if (Spawner.instance.player == null)
            Spawner.instance.player = this.transform;
        if (GoldSpawner.instance.player == null)
            GoldSpawner.instance.player = this.transform;
    }

    public void Die()
    {
        CameraManager.instance.SetSavedOrthographic();
        Instantiate(DieParticle, transform.position, Quaternion.identity);
        CameraManager.instance.GameOver();
        CameraManager.instance.lastTr = gameObject.transform;
        Destroy(gameObject);
    }
    
}
