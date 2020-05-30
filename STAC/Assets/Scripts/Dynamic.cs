using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dynamic : MonoBehaviour,IPointerDownHandler, IPointerUpHandler,IDragHandler
{
    public GameObject joystick;
    public void OnPointerDown(PointerEventData eventData)
    {
        joystick.transform.position = eventData.position;
        joystick.GetComponent<joystick>().isTouch = true;
      
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystick.GetComponent<joystick>().OnPointerUp(eventData);
        joystick.transform.position=new Vector3(-100,-100,0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        joystick.GetComponent<joystick>().OnDrag(eventData);
    }
}
