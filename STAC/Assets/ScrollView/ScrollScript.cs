using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollScript : ScrollRect
{
  ScrollManager SM;
  protected override void Start()
  {
    SM = GameObject.FindWithTag("ScrollManager").GetComponent<ScrollManager>();
  }

  public override void OnBeginDrag(PointerEventData eventData)
  {
    base.OnBeginDrag(eventData);
  }

  public override void OnDrag(PointerEventData eventData)
  {
    base.OnDrag(eventData);
  }

  public override void OnEndDrag(PointerEventData eventData)
  {
    base.OnEndDrag(eventData);
  }
}
