using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void exit()
    {
        anim.Play("DefaultAnim");
    }

    public void open()
    {
        anim.Play("SettingPanelAnim");
    }
}
