using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revival : MonoBehaviour
{
    public GameObject gameOverPanel;
    int maxTime;
    public float time;
    public Text text;
    public Image clock;
    void Start()
    {
        maxTime = (int)time;
    }

    void Update()
    {
        if (Input.touchCount > 0) //터치 시
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (time <= 1)
                {
                    time = 0;
                    clock.fillAmount = 0;
                }
                else
                {
                    time--;
                    clock.fillAmount -= 1;
                }
            }
        }
        
        
        time -= Time.deltaTime;
        clock.fillAmount -=  Time.deltaTime/maxTime;
        text.text = Mathf.CeilToInt(time).ToString();
        if (Mathf.CeilToInt(time) <= 0)
        {
            gameOverPanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
