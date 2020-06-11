using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelect : MonoBehaviour
{
    public GameObject[] Colors;
    void Start()
    {
        foreach (var color in Colors)
        {
            Instantiate(color,transform);
        }
    }
}
