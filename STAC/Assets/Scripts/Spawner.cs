using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public Transform player;
    public float radMinX, radMaxX, radMinY, radMaxY;
    public float[] delays;
    public float[] minusPercents;
    public float minusDelay;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < delays.Length; i++)
        {
            StartCoroutine(spawn(i));
            StartCoroutine(delayMinus(i));
        }
    }

    public void set(int index)
    {
        if (player != null)
            {
                int r = Random.Range(0, 6);
                GameObject enemy = ObjectManager.instance.MakeObj(index);
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
    IEnumerator spawn(int index)
    {
        while (true)
        { 
            yield return new WaitForSeconds(delays[index]);
            int random = Random.Range(0, 3);
            if(random==0) 
                set(index*2);
            else
                set(index*2+1);
        }
    }

    IEnumerator delayMinus(int index)
    {
        while (true)
        {
            yield return new WaitForSeconds(minusDelay);
            delays[index] = delays[index] - delays[index] * minusPercents[index];
        }
    }
}
