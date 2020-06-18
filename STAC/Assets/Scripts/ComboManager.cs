using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComboManager : MonoBehaviour
{
    public int ComboValue;
    public static ComboManager instance;
    public int comboCount = 0; //콤보횟수
    public bool canCombo = false; //콤보중인지 판단
    public float comboDelay; //콤보 간 지속될 수 있는 시간

    private void Start()
    {
        instance = this;
        comboDelay = 1;
    }

    public void comboIniitailize()
    {
        StopAllCoroutines();
        StartCoroutine(comboInitialization());
    }
    IEnumerator comboInitialization()
    {
        int value =ComboValue;
        canCombo = true;
        comboCount++;
        yield return new WaitForSeconds(comboDelay);
        canCombo = false;
        if (comboCount >= 2)
        {
            ScoreMgr.instance.comboInitialize(comboCount);
            value += comboCount / 5 * ComboValue;
            ScoreMgr.instance.scoreUp(comboCount, value * comboCount, true);
        }
        comboCount = 0;
    }

   
}
