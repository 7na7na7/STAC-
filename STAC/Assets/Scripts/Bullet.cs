using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    public TrailRenderer trail;
    public bool isColor1;
    public GameObject dieParticle;
    public int BulletIndex = 0;
    private Vector2 dir=Vector2.zero;
    private bool canDetect = true;

    private float speed;
    void Start()
    {
        speed = Random.Range(BulletData.instance.minSpeed, BulletData.instance.maxSpeed);
        transform.localScale = new Vector3(1/speed, 1/speed, transform.localScale.z);
        trail.startWidth *= 1/speed;
        trail.time += 1/Mathf.Pow(speed,2);
        switch (BulletIndex)
        {
            case 0:
                straight();
                break;
        }
    }

    private void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public void straight()
    {
        dir = Player.instance.transform.position-transform.position+new Vector3(Random.Range(BulletData.instance.playerAroundValue*-1,BulletData.instance.playerAroundValue),Random.Range(BulletData.instance.playerAroundValue*-1,BulletData.instance.playerAroundValue),0);
        dir.Normalize();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Color1") && !col.CompareTag("Color2")) //충돌체가 총알이 아니었을 경우
        {
            if (isColor1)
            {
                if (col.CompareTag("Edge1")) //같은 색에 닿았으면
                {
                    if(canDetect) 
                        SameColor();
                }
                else if (col.CompareTag("Edge2"))//다른 색이면
                {
                    if(canDetect) 
                        OtherColor();
                }
            }
            else
            {
                if (col.CompareTag("Edge2")) //같은 색에 닿았으면
                {
                    if(canDetect) 
                        SameColor();
                }
                else if (col.CompareTag("Edge1"))//다른 색이면
                {
                    if(canDetect) 
                        OtherColor(); 
                }
            }
        }
    }

    public void SameColor()
    {
        canDetect = false;
        ScoreMgr.instance.AddScore(GameManager.instance.scoreUpValue);
        Instantiate(dieParticle, transform.position, Quaternion.identity);
        Destroy(gameObject); //파괴
    }

    public void OtherColor()
    {
        canDetect = false;
        Player.instance.Die();
    }
}
