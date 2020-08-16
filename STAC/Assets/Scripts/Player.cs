using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject DieParticle;
    public static Player instance;
  
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (Spawner.instance.player == null)
            Spawner.instance.player = this.transform;
        if (GoldSpawner.instance.player == null)
            GoldSpawner.instance.player = this.transform;
        StartCoroutine(LiveScoreUp());
    }

    public void Die()
    {
        CameraManager.instance.SetSavedOrthographic();
        Instantiate(DieParticle, transform.position, Quaternion.identity);
        CameraManager.instance.GameOver();
        CameraManager.instance.lastTr = gameObject.transform;
        Destroy(gameObject);
    }

    IEnumerator LiveScoreUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ScoreMgr.instance.scoreUp(0,GameManager.instance.liveScoreUpValue,false,false);
        }
    }
}
