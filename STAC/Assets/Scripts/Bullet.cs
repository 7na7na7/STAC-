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
    private bool canDestroy = false;
    void Start()
    {
        if (isColor1)
            gameObject.tag = "Color1";
        else
            gameObject.tag = "Color2";

        speed = Random.Range(BulletData.instance.minSpeed, BulletData.instance.maxSpeed);
        if(BulletIndex==0) 
            transform.localScale = new Vector3(1/speed, 1/speed, transform.localScale.z);
        else if(BulletIndex==1)
            transform.localScale = new Vector3(1/speed/3f, 1/speed/3f, transform.localScale.z);
        trail.startWidth *= 1/speed;
        trail.time += 1/Mathf.Pow(speed,2);
        switch (BulletIndex)
        {
            case 0:
                straight();
                break;
            case 1:
                guide();
                break;
        }
    }

    private void Update()
    {
        if (!CheckCamera.instance.CheckObjectIsInCamera(gameObject))
        {
            if (!canDestroy)
            {
                canDestroy = true;
                StartCoroutine(Destroy());
            }
        }

        transform.Translate(dir * speed * Time.deltaTime);
    }

    public void straight()
    {
        dir = Player.instance.transform.position-transform.position+new Vector3(Random.Range(BulletData.instance.playerAroundValue*-1,BulletData.instance.playerAroundValue),Random.Range(BulletData.instance.playerAroundValue*-1,BulletData.instance.playerAroundValue),0);
        dir.Normalize();
    }

    public void guide()
    {
        StartCoroutine(guided());
    }

    IEnumerator guided()
    {
        while (true)
        {
            if (Player.instance != null)
            {
                dir = Player.instance.transform.position - transform.position;
                dir.Normalize();
            }
            yield return new WaitForSeconds(.1f);
        }
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

    IEnumerator Destroy() //10초동안 보이지 않으면 파괴
    {
        for(int i=0;i<60;i++)
        {
            yield return new WaitForSeconds(0.5f);
            if (CheckCamera.instance.CheckObjectIsInCamera(gameObject))
            {
                canDestroy = false;
                yield break;
            }
        }
        Destroy(gameObject);
    }
}
