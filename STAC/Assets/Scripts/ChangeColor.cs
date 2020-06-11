using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public void ColorChange(int value)
    {
        BulletData.instance.currentColorIndex = value;
    }
}
