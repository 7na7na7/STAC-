using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public Renderer RD;
    public Color color;

    void Start()
    {
     RD.material.SetColor("_Color",color);
    }
}
