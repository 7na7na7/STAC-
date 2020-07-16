using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class level
{
    public int[] bulletIndex;
    public int[] bulletPos;
}
public class Spawner2 : MonoBehaviour
{
    public Transform[] trianglePos;
    public Transform[] squarePos;
    public level[] levels;
    public float beat;
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            for(int i=0;i<levels.Length;i++)
            {
                yield return new WaitForSeconds(beat);
                if (levels[i].bulletIndex.Length != 0 && levels[i].bulletPos.Length != 0) //없으면 스킵
                {
                    if (levels[i].bulletIndex.Length == 1 || levels[i].bulletPos.Length == 1) //하나만 소환이면
                    {
                        GameObject enemy = ObjectManager.instance.MakeObj(levels[i].bulletIndex[0] + 11);
                        if (levels[i].bulletPos[0] <= 3) //삼각형이면
                        {
                            enemy.transform.position = trianglePos[levels[i].bulletPos[0]].position;
                            enemy.transform.eulerAngles =
                                new Vector3(0, 0, trianglePos[levels[i].bulletPos[0]].eulerAngles.z);
                        }
                        else //사각형이면
                        {
                            enemy.transform.position = squarePos[levels[i].bulletPos[0] - 4].position;
                            enemy.transform.eulerAngles =
                                new Vector3(0, 0, squarePos[levels[i].bulletPos[0] - 4].eulerAngles.z);
                        }
                    }
                }
            }
        }
     
    }
}
