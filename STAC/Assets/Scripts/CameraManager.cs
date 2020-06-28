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

    public Transform lastTr;
    private float savedOrthoSize;
    void Start()
    {
        if (instance == null)
            instance = this;

        savedOrthoSize = Camera.main.orthographicSize;
    }
    void Update()
    {
        if (player != null)
        {
            if (speed == 0)
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            //Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime); //Vector3.Lerp()를 쓰면 부드럽게 움직인다.
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
        GameObject playerGO=Instantiate(player_GO, lastTr);
        player = playerGO;
        FindObjectOfType<Tile>().transform.position = playerGO.transform.position;
        gameoverPanel.SetActive(false);
        Clock.SetActive(false);
        FindObjectOfType<joystick>().go_Player = playerGO;
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
