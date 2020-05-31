using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBG : MonoBehaviour
{
    public float speed;
    private bool isDown = true;
    void Update()
    {
        if (transform.localPosition.y <= -15)
        {
            isDown = false;
        }

        if (transform.localPosition.y >= 17)
        {
            isDown = true;
        }
        if(isDown)
            transform.Translate(0,Time.deltaTime*-speed,0);
        else
            transform.Translate(0,Time.deltaTime*speed,0);
    }
}
