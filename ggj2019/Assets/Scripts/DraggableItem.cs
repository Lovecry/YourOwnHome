using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] Image m_itemImage;

    public event System.Action<Vector3, Sprite> m_onEndDragItem;

    public void SetImage(Sprite itemImage)
    {
        m_itemImage.sprite = itemImage;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        mousePosWorld.z = 0;
        transform.position = mousePosWorld;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject.Destroy(this.gameObject);
        if (m_onEndDragItem != null)
            m_onEndDragItem(transform.position, m_itemImage.sprite);
    }
}
