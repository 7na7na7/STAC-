using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public int ColorIndex;
    public Renderer RD;
    private Color color;
    void Start()
    {
        color = BulletData.instance.SetColor(ColorIndex);
        color.a = 0;
        GetComponent<SpriteRenderer>().color = BulletData.instance.SetColor(ColorIndex);
     RD.material.SetColor("_Color",color);
    }
}
