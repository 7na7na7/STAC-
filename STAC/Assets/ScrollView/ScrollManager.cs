using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private bool isFirst = false;
    
    public Scrollbar scrollbar;
    public Transform contentTr;
    
    
    private const int SIZE = 3;
    private float[] pos = new float[SIZE];
    private float distance, curPos, targetPos;
    private bool isDrag;
    private int targetIndex;
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
        
        //절반거리를 넘지 않아도 마우스를 빠르게 이동하려면
        if (curPos == targetPos) //처음드래그시작한 위치와 드래그 끝난 위치가 같다면
        {
            //스크롤이 왼쪽으로 빠르게 이동시 목표가 하나 감소
            if (eventData.delta.x > 18 && curPos - distance >= 0)
            {
                --targetIndex;
                targetPos = curPos - distance;
            }
            //스크롤이 오른쪽으로 빠르게 이동시 목표가 하나 증가
            else if (eventData.delta.x < -18 && curPos - distance <=1f)
            {
                ++targetIndex;
                targetPos = curPos + distance;
            }
        }
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
                scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);
            }
        }
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
