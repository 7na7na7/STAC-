using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public ParticleSystem[] particles;
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
        FindObjectOfType<Rotate>().rotateParticles[0] = particles[0];
        FindObjectOfType<Rotate>().rotateParticles[1] = particles[1];
        FindObjectOfType<Rotate>().rotateParticles[2] = particles[2];
    }

    public void Die()
    {
        Flash.instance.flash();
        CameraManager.instance.SetSavedOrthographic();
        Instantiate(DieParticle, transform.position, Quaternion.identity);
        CameraManager.instance.GameOver();
        CameraManager.instance.lastTr = gameObject.transform;
        Vibrate.instance.Vibe(750);
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
