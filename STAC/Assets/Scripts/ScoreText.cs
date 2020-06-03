using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = ScoreMgr.instance.score.ToString();
    }
}
