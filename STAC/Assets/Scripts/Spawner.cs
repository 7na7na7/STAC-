using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[System.Serializable]
public class difficulty
{
    public float delay; //몇 초 후에
    public float[] percents; //확률을 어떻게 바꿀것인가
}
public class Spawner : MonoBehaviour
{
    public difficulty[] levels;
    public GameObject[] bulletKind;
    public ArrayList bulletList= new ArrayList();
    public float radMinX, radMaxX, radMinY, radMaxY;
    public float minDelay, maxDelay;
    public float delayMinusValue_Min;
    public float delayMinusValue_Max;
    public float delyaMinusTime;
    void Start()
    {
        StartCoroutine(spawn());
        StartCoroutine(percentHarder());
        StartCoroutine(delayHarder());
    }

    public void Set(float[] perc)
    {
        bulletList.Clear();
        for (int i = 0; i < bulletKind.Length; i++)
        {
            for (int j = 0; j < bulletKind.Length * (perc[i] / 100) * 10; j++)
            {
                bulletList.Add(i);
            }
        }
    }
    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay,maxDelay));
            
            int bulletIndex=0;
            bulletIndex = (int)bulletList[Random.Range(0, bulletList.Count)];
         
            int r = Random.Range(0, 6);
            if (r == 0||r==1) //위
            {
                Instantiate(bulletKind[bulletIndex], new Vector2(
                    Random.Range(transform.position.x-radMaxX,transform.position.x+radMaxX), 
                    Random.Range(transform.position.y+radMinY,transform.position.y+radMaxY)), Quaternion.identity);
            }
            else if (r == 2||r==3) //아래
            {
                Instantiate(bulletKind[bulletIndex], new Vector2(
                    Random.Range(transform.position.x-radMaxX,transform.position.x+radMaxX), 
                    Random.Range(transform.position.y-radMinY,transform.position.y-radMaxY)), Quaternion.identity);
            }
            else if (r == 4) //오른쪽
            {
                Instantiate(bulletKind[bulletIndex], new Vector2(
                    Random.Range(transform.position.x+radMinX,transform.position.x+radMaxX), 
                    Random.Range(transform.position.y-radMinY,transform.position.y+radMinY)), Quaternion.identity);
            }
            else if (r == 5) //왼쪽
            {
                Instantiate(bulletKind[bulletIndex], new Vector2(
                    Random.Range(transform.position.x-radMinX,transform.position.x-radMaxX), 
                    Random.Range(transform.position.y-radMinY,transform.position.y+radMinY)), Quaternion.identity);
            }
        }
    }

    IEnumerator percentHarder()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            yield return new WaitForSeconds(levels[i].delay);
            Set(levels[i].percents);
        }
    }

    IEnumerator delayHarder()
    {
        while (true)
        {
         yield return new WaitForSeconds(delyaMinusTime);
         minDelay -= delayMinusValue_Min;
         maxDelay -= delayMinusValue_Max;
        }
    }
}
