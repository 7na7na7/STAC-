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
    public static Spawner instance;
    public Transform player;
    public ArrayList bulletList= new ArrayList();
    public float radMinX, radMaxX, radMinY, radMaxY;
    public float minDelay, maxDelay;
    public float delayMinusValue_Min;
    public float delayMinusValue_Max;
    public float delyaMinusTime;
    public difficulty[] levels;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(spawn());
        StartCoroutine(percentHarder());
        StartCoroutine(delayHarder());
    }

    public void Set(float[] perc)
    {
        bulletList.Clear();
        for (int i = 0; i <ObjectManager.instance.bulletNum; i++)
        {
            for (int j = 0; j < ObjectManager.instance.bulletNum * (perc[i] / 100) * 10; j++)
            {
                bulletList.Add(i);
                print(i);
            }
        }
    }
    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay,maxDelay));
            if (player != null)
            {
                int bulletIndex=0;
                bulletIndex = (int)bulletList[Random.Range(0, bulletList.Count)];
         
                int r = Random.Range(0, 6);
                GameObject enemy = ObjectManager.instance.MakeObj(bulletIndex);
                if (r == 0||r==1) //위
                {
                    enemy.transform.position = new Vector2(
                        Random.Range(player.position.x - radMaxX*Camera.main.orthographicSize, player.position.x + radMaxX*Camera.main.orthographicSize),
                        Random.Range(player.position.y + radMinY*Camera.main.orthographicSize, player.position.y + radMaxY*Camera.main.orthographicSize));
                }
                else if (r == 2||r==3) //아래
                {
                    enemy.transform.position = new Vector2(
                        Random.Range(player.position.x-radMaxX*Camera.main.orthographicSize,player.position.x+radMaxX*Camera.main.orthographicSize), 
                        Random.Range(player.position.y-radMinY*Camera.main.orthographicSize,player.position.y-radMaxY*Camera.main.orthographicSize));
                }
                else if (r == 4) //오른쪽
                {
                    enemy.transform.position = new Vector2(
                        Random.Range(player.position.x + radMinX*Camera.main.orthographicSize, player.position.x + radMaxX*Camera.main.orthographicSize),
                        Random.Range(player.position.y - radMinY*Camera.main.orthographicSize, player.position.y + radMinY*Camera.main.orthographicSize));
                }
                else if (r == 5) //왼쪽
                {
                    enemy.transform.position = new Vector2(
                        Random.Range(player.position.x - radMinX*Camera.main.orthographicSize, player.position.x - radMaxX*Camera.main.orthographicSize),
                        Random.Range(player.position.y - radMinY*Camera.main.orthographicSize, player.position.y + radMinY*Camera.main.orthographicSize));
                }   
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
