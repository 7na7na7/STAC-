using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Clock;
    public static CameraManager instance;
    public float speed;
    public GameObject player; //여기에다가 따라갈거 넣는다.
    Transform AT;
    void Start()
    {
        if (instance == null)
            instance = this;
        AT = player.transform;
    }
    void Update()
    {
        if (AT != null)
        {
            if (speed == 0)
                transform.position = AT.position;
            else
                transform.position = Vector3.Lerp(transform.position, AT.position, speed * Time.deltaTime); //Vector3.Lerp()를 쓰면 부드럽게 움직인다.
            transform.position=new Vector3(transform.position.x, transform.position.y, -10); //카메라를 원래 z축으로 이동   
        }
    }

    public void GameOver(GameObject g)
    {
        StartCoroutine(targetChange(g));
    }
    public IEnumerator targetChange(GameObject g)
    {
        Time.timeScale = 0.2f;
        while (Camera.main.orthographicSize > 2f)
        {
            Camera.main.orthographicSize -= 0.1f;
            transform.position = Vector3.Lerp(transform.position, g.transform.position, speed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1;
        Fade.instance.fade();
        Clock.SetActive(true);
    }
}
