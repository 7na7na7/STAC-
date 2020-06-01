﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float speed;
    public GameObject player; //여기에다가 따라갈거 넣는다.
    Transform AT;
    void Start()
    {
        AT = player.transform;
    }
    void Update()
    {
        if (speed == 0)
            transform.position = AT.position;
        else
            transform.position = Vector3.Lerp(transform.position, AT.position, speed * Time.deltaTime); //Vector3.Lerp()를 쓰면 부드럽게 움직인다.
        transform.position=new Vector3(transform.position.x, transform.position.y, -10); //카메라를 원래 z축으로 이동
    }
}
