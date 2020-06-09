using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public float scrollSpeed;
    private bool isFirst = false;
    
    public Scrollbar scrollbar;
    public Transform contentTr;
    
    
    private const int SIZE = 3;
    private float[] pos = new float[SIZE];
    private float distance, curPos, targetPos;
    private bool isDrag;
    public int targetIndex;
    void Start()
    {
        //거리에 따라 0~1인 pos 대입
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;
    }
    public void OnBeginDrag(PointerEventData eventData) => curPos = SetPos();
    
    public void OnDrag(PointerEventData eventData)=> isDrag = true;

    public void OnEndDrag(PointerEventData eventData)
    { 
        isDrag = false;

        targetPos = SetPos();
        
        //목표가 수직스크롤이고, 옆에서 옮겨왔다면 수직스크롤을 맨 위로 옹림
        for(int i=0;i<SIZE;i++)
            if (contentTr.GetChild(i).GetComponent<ScrollScript>() && curPos != pos[i] && targetPos == pos[i])
                contentTr.GetChild(i).GetChild(1).GetComponent<Scrollbar>().value = 1;
    }

    void Update()
    {
        if (!isFirst)
        {
            isFirst = true;
            targetIndex = 1;
            scrollbar.value = 0.5f;
            targetPos = 0.5f;
        }
        else
        {

            if (!isDrag)
            {
                scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, scrollSpeed);
            }
        }
    }

    public void Right()
    {
        targetPos = 1;
    }

    public void Left()
    {
        targetPos = 0;
    }

    public void Middle()
    {
        targetPos = 0.5f;
    }
    public float SetPos()
    {
        //절반거리를 기준으로 가까운 위치를 반환
        for(int i=0;i<SIZE;i++)
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetIndex = i;
                return pos[i];
            }
        return 0;
    }
}
