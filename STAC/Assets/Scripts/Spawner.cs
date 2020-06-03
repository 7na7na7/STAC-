using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] bullets;
    public float radMinX, radMaxX, radMinY, radMaxY;
    public float minDelay, maxDelay;
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay,maxDelay));

            int r = Random.Range(0, 4);
            if (r == 0) //3사분면
            {
                Instantiate(bullets[Random.Range(0, bullets.Length)], new Vector2(
                    Random.Range(transform.position.x-radMinX,transform.position.x-radMaxX), 
                    Random.Range(transform.position.y-radMinY,transform.position.y-radMaxY)), Quaternion.identity);
            }
            else if (r == 1) //4사분면
            {
                Instantiate(bullets[Random.Range(0, bullets.Length)], new Vector2(
                    Random.Range(transform.position.x-radMinX,transform.position.x-radMaxX), 
                    Random.Range(transform.position.y+radMinY,transform.position.y+radMaxY)), Quaternion.identity);
            }
            else if (r == 2) //1사분면
            {
                Instantiate(bullets[Random.Range(0, bullets.Length)], new Vector2(
                    Random.Range(transform.position.x+radMinX,transform.position.x+radMaxX), 
                    Random.Range(transform.position.y+radMinY,transform.position.y+radMaxY)), Quaternion.identity);
            }
            else if (r == 3) //2사분면
            {
                Instantiate(bullets[Random.Range(0, bullets.Length)], new Vector2(
                    Random.Range(transform.position.x+radMinX,transform.position.x+radMaxX), 
                    Random.Range(transform.position.y-radMinY,transform.position.y-radMaxY)), Quaternion.identity);
            }
        }
    }

 
}
