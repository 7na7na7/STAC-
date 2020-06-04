using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public static BulletData instance;
    public float playerAroundValue;
    public float minSpeed, maxSpeed;
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
