using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBG : MonoBehaviour
{
    public float speed;
    public bool isDown = true;
    public float minY, maxY;
    void Update()
    {
        if (transform.localPosition.y <= minY)
        {
            isDown = false;
        }
        if (transform.localPosition.y >= maxY)
        {
            isDown = true;
        }
        if(isDown)
            transform.Translate(0,Time.deltaTime*-speed,0);
        else
            transform.Translate(0,Time.deltaTime*speed,0);
    }
}
