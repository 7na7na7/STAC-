using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSetFalse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Bullet[] bullets = FindObjectsOfType<Bullet>();
        foreach (var bullet in bullets)
        {
            bullet.SetFalse();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
