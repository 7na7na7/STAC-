using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickScale : MonoBehaviour
{
    public float JoystickSize;
    public static JoyStickScale instance;

    private string joystickScalekey = "joystickscale";
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            JoystickSize = PlayerPrefs.GetFloat(joystickScalekey, 0.5f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSize()
    {
        
    }
}
