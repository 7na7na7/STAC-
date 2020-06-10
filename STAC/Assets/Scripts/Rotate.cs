using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rotate : MonoBehaviour
{
    public bool AutoRotate = false;
    public RectTransform rotate;
    public float autoRotateDelay;
    public bool isRight = true;
    
    private bool canRotate = true;
    
    public float delay;
    public int value;
    public ParticleSystem[] rotateParticles;

    private void Start()
    {
        if (AutoRotate)
            StartCoroutine(autoRotate());
    }

    private void Update()
    {
        int speed = 10;
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


        if(Input.GetKeyDown(KeyCode.J))
            Left();
        else if(Input.GetKeyDown(KeyCode.K))
            Right();
    }
    public void Left()
    {
        if(canRotate) 
            StartCoroutine(LeftCor());
    }

    public void Right()
    {
        if(canRotate) 
            StartCoroutine(RightCor());
    }

    public void randomSound()
    {
        SoundMgr.instance.Play(Random.Range(1,7),1,1.5f);
    }
    IEnumerator LeftCor()
    {
        randomSound();
        canRotate = false;
        for(int i=0;i<120/value;i++)
        {
            if(transform.eulerAngles.z+value>=370)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - value);
            else
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + value);
            yield return new WaitForSeconds(delay);
        }
        transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,Mathf.CeilToInt(transform.eulerAngles.z*10)/10);
        canRotate = true;
        Emission();
    }
    IEnumerator RightCor()
    {
        randomSound();
        canRotate = false;
        for(int i=0;i<120/value;i++)
        {
            if(transform.eulerAngles.z-value<=-10)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 360-transform.eulerAngles.z - value);
            else
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - value);
            yield return new WaitForSeconds(delay);
        }
        transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,Mathf.CeilToInt(transform.eulerAngles.z*10)/10);
        canRotate = true;
       Emission();
    }

    public void ChangeRotate()
    {
        rotate.localScale=new Vector3(rotate.localScale.x*-1,rotate.localScale.y,rotate.localScale.z);
        isRight = !isRight;
        //이미지 좌우반전시키기
    }
    IEnumerator autoRotate()
    {
        Screen.SetResolution(1080,1920,true);
        while (true)
        {
            yield return new WaitForSeconds(autoRotateDelay);
            if (isRight)
                Right();
            else
                Left();
        }
    }
    public void Emission()
    {
        foreach (ParticleSystem p in rotateParticles)
        {
            p.Play();
        }
    }
}
