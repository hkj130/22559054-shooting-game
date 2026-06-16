using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image iconImage;
    public TMP_Text countText;

    private InventoryUI inventoryUI;
    private List<InventoryItem> itemList;
    private int index;


    public void RefreshView()
    {
        if (itemList == null || index < 0 || index >= itemList.Count)
        {
            return;
        }

        InventoryItem item = itemList[index];

        if (item != null && item.data != null)
        {
            iconImage.enabled = true;
            iconImage.sprite = item.data.icon;
            iconImage.color = Color.white;
        }
        else
        {
            iconImage.enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            InventorySlotUI startSlot = eventData.pointerDrag.GetComponent<InventorySlotUI>();

            if (startSlot != null)
            {

                Debug.Log($"{startSlot.index}번 슬롯에서 {this.index}번 슬롯으로 아이템 이동 요청");
            }
        }
    }
}
