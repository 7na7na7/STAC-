using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    public GameObject[] clusterObj = null;
    public TrailRenderer trail;
    public bool isColor1;
    public GameObject dieParticle;
    public int BulletIndex = 0;
    public Vector2 dir=Vector2.zero;
    private bool canDetect = true;
    public float minSpeed, maxSpeed;
    public float speed;
    private bool canDestroy = false;
    void Start()
    {
        if (isColor1)
            gameObject.tag = "Color1";
        else
            gameObject.tag = "Color2";

        if (BulletIndex != 3)
        {
            speed = Random.Range(minSpeed,maxSpeed);
            Set();   
        }

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
            case 2:
                straight();
                break;
        }
    }
    public void delayGuide()
    {
        StartCoroutine(delayGuideCor());
    }

    IEnumerator delayGuideCor()
    {
        yield return new WaitForSeconds(0.5f);
        guide();
    }
    public void Set()
    {
        if(BulletIndex==1)
            transform.localScale = new Vector3(1/speed/3f, 1/speed/3f, transform.localScale.z);
        else if(BulletIndex==2)
            transform.localScale = new Vector3(1/speed/2f, 1/speed/2f, transform.localScale.z);
        else if(BulletIndex==3)
            transform.localScale = new Vector3(1/speed/2f, 1/speed/2f, transform.localScale.z);
        else
            transform.localScale = new Vector3(1/speed, 1/speed, transform.localScale.z);
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
    public void cluster()
    {
        GameObject obj1=Instantiate(clusterObj[0], transform.position, Quaternion.identity);
        GameObject obj2= Instantiate(clusterObj[1], transform.position, Quaternion.identity);
        
        obj1.GetComponent<Bullet>().speed = speed * 2;
        obj1.GetComponent<Bullet>().Set();
        obj1.GetComponent<Bullet>().dir=new Vector2( dir.x+1, dir.y);
        obj1.GetComponent<Bullet>().dir.Normalize();
        obj1.GetComponent<Bullet>().delayGuide();
                
        obj2.GetComponent<Bullet>().speed = speed * 2;
        obj2.GetComponent<Bullet>().Set();
        obj2.GetComponent<Bullet>().dir=new Vector2( dir.x, dir.y+1);
        obj2.GetComponent<Bullet>().dir.Normalize();
        obj2.GetComponent<Bullet>().delayGuide();

        Destroy(gameObject);
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

        if (col.CompareTag("Cluster"))
        {
            if(BulletIndex==2)
                cluster();
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
        for(int i=0;i<20;i++)
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
