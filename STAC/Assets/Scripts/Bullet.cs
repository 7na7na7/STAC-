using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
        dir = Player.instance.transform.position-transform.position;
        dir.Normalize();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Color1") && !col.CompareTag("Color2")) //충돌체가 총알이 아니었을 경우
        {
            Destroy(gameObject); //파괴
        }
    }
}
