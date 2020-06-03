using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    public bool isColor1;
    public float playerAroundValue;
    public GameObject dieParticle;
    public int BulletIndex = 0;
    public float speed;
    private Vector2 dir=Vector2.zero;
    void Start()
    {
        switch (BulletIndex)
        {
            case 0:
                straight();
                break;
        }
    }

    private void Update()
    {
        transform.Translate(dir*speed*Time.deltaTime);
    }

    public void straight()
    {
        dir = Player.instance.transform.position-transform.position+new Vector3(Random.Range(playerAroundValue*-1,playerAroundValue),Random.Range(playerAroundValue*-1,playerAroundValue),0);
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
                    Instantiate(dieParticle, transform.position, Quaternion.identity);
                        Destroy(gameObject); //파괴       
                }
            }
            else
            {
                if (col.CompareTag("Edge2")) //같은 색에 닿았으면
                {
                    Instantiate(dieParticle, transform.position, Quaternion.identity);
                        Destroy(gameObject); //파괴
                }
            }
           
        }
    }
}
