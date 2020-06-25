using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldCol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Edge1")||other.CompareTag("Edge2"))
        {
            GoldManager.instance.GetGold(10);
            Destroy(gameObject);
        }
    }
}
