using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragMove : MonoBehaviour
{
    public float speed;
    public GameObject player;
    private void Update()
    {
        
        //if (Input.GetMouseButton(0))
        if(Input.GetTouch(0).phase==TouchPhase.Stationary||Input.GetTouch(0).phase==TouchPhase.Moved)
        {
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition)-player.transform.position;
            dir.Normalize();
            print(dir);
            player.transform.position += new Vector3(dir.x * speed * Time.deltaTime,dir.y*speed*Time.deltaTime,0);
        }
    }
}
