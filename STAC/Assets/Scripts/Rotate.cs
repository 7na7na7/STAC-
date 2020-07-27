using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Rotate : MonoBehaviour
{
    //public RectTransform rotate;
    public bool isRight = true;

    public float delay;
    public int bpm;
    private double currentTime = 0d;
    public int value;
    public ParticleSystem[] rotateParticles;

    private void Update()
    {
        #region 임시이동회전코드
        int speed = 6;
        Vector3 moveVelocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") > 0)//오른쪽으로 갈때
        { 
            moveVelocity = Vector3.right;
            transform.position += moveVelocity * speed * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)//왼쪽으로 갈때
        { 
            moveVelocity = Vector3.left;
            transform.position += moveVelocity * speed * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Vertical") > 0)//위
        {
            moveVelocity = Vector3.up;
            transform.position += moveVelocity * speed * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Vertical") < 0)//아래
        { 
            moveVelocity = Vector3.down;
            transform.position += moveVelocity * speed * Time.deltaTime;
        }
        #endregion
        
            currentTime += Time.deltaTime;

            if (currentTime >= 60d / bpm)
            {
                StartCoroutine(RotateCor(isRight));
                currentTime -= 60d / bpm;
            }
    }
    public void RotateSound()
    {
        SoundMgr.instance.Play(2,1,1);
    }
    IEnumerator RotateCor(bool isR)
    {
     
            if (isR)
            {
                for(int i=0;i<120/value;i++)
                {
                    if(transform.eulerAngles.z+value>=400)
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - value);
                    else
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + value);
                    yield return new WaitForSeconds(delay);
                }
            }
            else
            {
                for(int i=0;i<120/value;i++)
                {
                    if(transform.eulerAngles.z+value>=400)
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - value);
                    else
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + value);
                    yield return new WaitForSeconds(delay);
                }
                transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,Mathf.CeilToInt(transform.eulerAngles.z*10)/10);
            }
            RotateSound();
            Emission();
    }

//    public void ChangeRotate()
//    {
//        rotate.localScale=new Vector3(rotate.localScale.x*-1,rotate.localScale.y,rotate.localScale.z);
//        isRight = !isRight;
//        //이미지 좌우반전시키기
//    }

    public void Emission()
    {
        foreach (ParticleSystem p in rotateParticles)
        {
            p.Play();
        }
    }
}
