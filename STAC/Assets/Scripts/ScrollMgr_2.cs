using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollMgr_2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;
    private int SIZE = 4;
    private float[] pos;
    private float distance, curPos,targetPos;
    private bool isDrag;
    private int targetIndex;
    private float value = 0.5f;
    void Start()
    {
       pos= new float[SIZE];
        //거리에 따라 0~1인 pos 대입
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;
        value=1f/(SIZE-1);
    }
    
    void Update()
    {
        if(!isDrag) 
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);
    }

    public float SetPos()
    {
        //절반거리를 기준으로 가까운 위치를 반환
        for (int i = 0; i < SIZE; i++)
        {
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetIndex = i;
                return pos[i];
            }
        }
        if (scrollbar.value > 0.3f)
        {
            targetIndex = 0;
            return 0;
        }
        else
        {
            targetIndex = SIZE - 1;
            return 1;
        }
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        curPos = SetPos();
        value = scrollbar.value;
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    { 
        isDrag = false;
        targetPos = SetPos();

        //절반거리를 넘지 않아도 마우스를 빠르게 이동하려면
        if (curPos == targetPos) //처음드래그시작한 위치와 드래그 끝난 위치가 같다면
        {
            if (Mathf.Abs(eventData.delta.x) > 8)
            {
                //스크롤이 왼쪽으로 빠르게 이동시 목표가 하나 감소
                if (scrollbar.value < value) //왼쪽이면
                {
                    if (targetIndex == 0)
                    {
                        targetIndex = SIZE-1;
                        targetPos = 1;
                    }
                    else
                    {
                        --targetIndex;
                        targetPos = curPos - distance;
                    }
                }
                else
                {
                    if (targetIndex == SIZE-1)
                    {
                        targetIndex = 0;
                        targetPos = 0;
                    }
                    else
                    {
                        ++targetIndex;
                        targetPos = curPos + distance;
                    }
                }
            }
        }

    }
}
