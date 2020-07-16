using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    private bool canDestroy = false;
    
    public float speed;
    public GameObject dieParticle;
    public bool isColor1;
    private bool canDetect = true;
    
    private void OnEnable()
    {
        GetComponent<SetColor>().setColor();
            canDestroy = false;
            canDetect = true;
            if (isColor1)
                gameObject.tag = "Color1";
            else
                gameObject.tag = "Color2";
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
        
        ScoreMgr.instance.scoreUp(0,GameManager.instance.scoreUpValue,false);
        ComboManager.instance.comboIniitailize();
        
        
        Instantiate(dieParticle, transform.position, Quaternion.identity);
        if(SoundMgr.instance!=null) 
            SoundMgr.instance.Play(0,1,1);
        gameObject.SetActive(false);
    }

    public void OtherColor()
    {
        canDetect = false;
        Player.instance.Die();
    }

    private void Update()
    {
        transform.Translate(Vector3.right*speed*Time.deltaTime);
        
        if (!CheckCamera.instance.CheckObjectIsInCamera(gameObject)) //카메라에 안보이면 삭제
        {
            if (!canDestroy)
            {
                canDestroy = true;
                StartCoroutine(Destroy());
            }
        }
    }
    
    IEnumerator Destroy() //3초동안 보이지 않으면 파괴
    {
        for(int i=0;i<6;i++)
        {
            yield return new WaitForSeconds(0.5f);
            if (CheckCamera.instance.CheckObjectIsInCamera(gameObject))
            {
                canDestroy = false;
                yield break;
            }
        }
        gameObject.SetActive(false);
    }
}
