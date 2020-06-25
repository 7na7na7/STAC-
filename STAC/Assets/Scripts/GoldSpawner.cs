using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoldSpawner : MonoBehaviour
{
    public float minDelay, maxDelay;
    private float radMaxX, radMinY, radMinX,radMaxY;
    private void Start()
    {
        StartCoroutine(spawn());

        radMaxX = FindObjectOfType<Spawner>().radMaxX;
        radMinY = FindObjectOfType<Spawner>().radMinY;
        radMinX = FindObjectOfType<Spawner>().radMinX; 
        radMaxY = FindObjectOfType<Spawner>().radMaxY;
    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay,maxDelay));
            
GameObject gold=ObjectManager.instance.MakeObj(10);
            int r = Random.Range(0, 6);
            if (r == 0||r==1) //위
            {
                gold.transform.position = new Vector2(
                    Random.Range(transform.position.x - radMaxX, transform.position.x + radMaxX),
                    Random.Range(transform.position.y + radMinY, transform.position.y + radMaxY));
            }
            else if (r == 2||r==3) //아래
            {
                gold.transform.position = new Vector2(
                    Random.Range(transform.position.x-radMaxX,transform.position.x+radMaxX), 
                    Random.Range(transform.position.y-radMinY,transform.position.y-radMaxY));
            }
            else if (r == 4) //오른쪽
            {
                gold.transform.position = new Vector2(
                    Random.Range(transform.position.x + radMinX, transform.position.x + radMaxX),
                    Random.Range(transform.position.y - radMinY, transform.position.y + radMinY));
            }
            else if (r == 5) //왼쪽
            {
                gold.transform.position = new Vector2(
                    Random.Range(transform.position.x - radMinX, transform.position.x - radMaxX),
                    Random.Range(transform.position.y - radMinY, transform.position.y + radMinY));
            }
        }
    }

}
