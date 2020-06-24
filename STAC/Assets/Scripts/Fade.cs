using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public static Fade instance;
    public float delay;
    public float value;
    private Color color;
    private Image image;
    void Start()
    {
        if (instance == null)
            instance = this;
        image = GetComponent<Image>();
        color = image.color;
    }

    public void fade()
    {
        StartCoroutine(fadeCor());
    }
    IEnumerator fadeCor()
    {
        GetComponent<Image>().raycastTarget = true;
        while (color.a<0.5)
        {
            yield return new WaitForSecondsRealtime(delay);
            color.a += value;
            image.color = color;
        }
    }
    
    public void Unfade()
    {
        StartCoroutine(UnfadeCor());
    }
    IEnumerator UnfadeCor()
    {
        while (color.a>0)
        {
            yield return new WaitForSecondsRealtime(delay);
            color.a -= value;
            image.color = color;
        }
        GetComponent<Image>().raycastTarget = false;
    }
}
