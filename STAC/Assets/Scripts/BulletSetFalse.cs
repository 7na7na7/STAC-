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
        Bullet2[] bullet2s = FindObjectsOfType<Bullet2>();
        foreach (var bullet in bullet2s)
        {
            bullet.SetFalse();
        }
        goldCol[] golds = FindObjectsOfType<goldCol>();
        foreach (var bullet in golds)
        {
            bullet.SetFalse();
        }
    }
}
