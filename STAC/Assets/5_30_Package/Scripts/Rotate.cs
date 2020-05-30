using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private bool canRotate = true;
    
    public float delay;
    public float value;
    public void Left()
    {
        if(canRotate) 
            StartCoroutine(LeftCor());
    }

    public void Right()
    {
        if(canRotate) 
            StartCoroutine(RightCor());
    }

    IEnumerator LeftCor()
    {
        canRotate = false;
        for(int i=0;i<120/value;i++)
        {
            if(transform.eulerAngles.z+value>=360)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - value);
            else
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + value);
            yield return new WaitForSeconds(delay);
        }
        transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,Mathf.CeilToInt(transform.eulerAngles.z*10)/10);
        canRotate = true;
    }
    IEnumerator RightCor()
    {
        canRotate = false;
        for(int i=0;i<120/value;i++)
        {
            if(transform.eulerAngles.z-value<=0)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 360-transform.eulerAngles.z - value);
            else
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - value);
            yield return new WaitForSeconds(delay);
        }
        transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,Mathf.CeilToInt(transform.eulerAngles.z*10)/10);
        canRotate = true;
    }
}
