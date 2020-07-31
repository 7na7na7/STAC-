using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoldSpawner : MonoBehaviour
{
    public static GoldSpawner instance;
    public float minDelay, maxDelay;
    private float radMaxX, radMinY, radMinX,radMaxY;
    public Transform player;

    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        StartCoroutine(spawn());

        radMaxX = FindObjectOfType<Spawner>().radMaxX*Camera.main.orthographicSize;
        radMinY = FindObjectOfType<Spawner>().radMinY*Camera.main.orthographicSize;
        radMinX = FindObjectOfType<Spawner>().radMinX*Camera.main.orthographicSize; 
        radMaxY = FindObjectOfType<Spawner>().radMaxY*Camera.main.orthographicSize;
    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay,maxDelay));
            if (player != null)
            {
                GameObject gold=ObjectManager.instance.MakeObj(102);
                int r = Random.Range(0, 6);
                if (r == 0||r==1) //위
                {
                    gold.transform.position = new Vector2(
                        Random.Range(player.position.x - radMaxX, player.position.x + radMaxX),
                        Random.Range(player.position.y + radMinY, player.position.y + radMaxY));
                }
                else if (r == 2||r==3) //아래
                {
                    gold.transform.position = new Vector2(
                        Random.Range(player.position.x-radMaxX,player.position.x+radMaxX), 
                        Random.Range(player.position.y-radMinY,player.position.y-radMaxY));
                }
                else if (r == 4) //오른쪽
                {
                    gold.transform.position = new Vector2(
                        Random.Range(player.position.x + radMinX, player.position.x + radMaxX),
                        Random.Range(player.position.y - radMinY, player.position.y + radMinY));
                }
                else if (r == 5) //왼쪽
                {
                    gold.transform.position = new Vector2(
                        Random.Range(player.position.x - radMinX, player.position.x - radMaxX),
                        Random.Range(player.position.y - radMinY, player.position.y + radMinY));
                }   
            }
        }
    }

}
