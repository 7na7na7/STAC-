using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public int ColorIndex;
    public Renderer RD;
    public Color color;
    void Start()
    {
        GetComponent<SpriteRenderer>().color = BulletData.instance.SetColor(ColorIndex);
     RD.material.SetColor("_Color",color);
    }
}
