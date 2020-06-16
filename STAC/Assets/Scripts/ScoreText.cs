using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public static ScoreText instance;
    private Text Txt;
    public float delay;
    private void Start()
    {
        instance = this;
        Txt = GetComponent<Text>();
    }

    void Update()
    {
        Txt.text = ScoreMgr.instance.score.ToString();
    }

    public void pong()
    {
        StopAllCoroutines();
        StartCoroutine(size());
    }
    public IEnumerator size()
    {
        while (Txt.fontSize < 300)
            {
                Txt.fontSize += 2;

                yield return new WaitForSeconds(delay);
            }

            while (Txt.fontSize > 250)
            {
                Txt.fontSize -= 2;

                yield return new WaitForSeconds(delay);
            }
    }
}
