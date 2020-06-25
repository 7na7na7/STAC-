using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Clock;
    public GameObject gameoverPanel;
    public static CameraManager instance;
    public float speed;
    public GameObject player; //여기에다가 따라갈거 넣는다.
    public GameObject player_GO; //플레이어 게임오브젝트
    Transform AT;

    public Transform lastTr;
    private float savedOrthoSize;
    void Start()
    {
        if (instance == null)
            instance = this;
        AT = player.transform;

        savedOrthoSize = Camera.main.orthographicSize;
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

    public void GameOver()
    {
        StartCoroutine(targetChange());
    }
    public IEnumerator targetChange()
    {
        BGM.instance.fadeOut();
        Time.timeScale = 0.3f;
        float size = Camera.main.orthographicSize-3;
        while (Camera.main.orthographicSize > size)
        {
            Camera.main.orthographicSize -= 0.05f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSecondsRealtime(0.5f);
        
        Time.timeScale = 1;
        Fade.instance.fade();
        if (GameManager.instance.canRevival)
        {
            GameManager.instance.canRevival = false;
            Clock.SetActive(true);
        }
        else
        {
            gameoverPanel.SetActive(true);
        }
    }

    public void Revival()
    {
        BGM.instance.fadeIn();
        Bullet[] bullets = FindObjectsOfType<Bullet>();
        foreach (var bullet in bullets)
        {
            bullet.SetFalse();
        }
        StartCoroutine(targetChange2());
        Fade.instance.Unfade();
        GameObject player=Instantiate(player_GO, lastTr);
        gameoverPanel.SetActive(false);
        Clock.SetActive(false);
        FindObjectOfType<joystick>().go_Player = player;
        AT = player.transform;
    }
    
    public IEnumerator targetChange2()
    {
        Time.timeScale = 1;
        float size = savedOrthoSize;
        while (Camera.main.orthographicSize < size)
        {
            Camera.main.orthographicSize += 0.05f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
