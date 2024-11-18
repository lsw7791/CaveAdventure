using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    public ItemSlot slot;

    public void SetSlot(ItemSlot selectedSlot)
    {
        slot = selectedSlot;
        Debug.Log("Selected slot updated with item: " + (slot.currentItem != null ? slot.currentItem.name : "No item"));
    }

    public void UseItem()
    {
        if (slot != null && slot.currentItem != null)
        {
            ItemSO item = slot.currentItem; // ItemSO를 가져옴
            Debug.Log("Using item: " + item.name);

            // 아이템 사용에 따른 로직 추가
            // 예: item.Use(); // 아이템 사용 메서드가 있다면 호출
        }
        else
        {
            Debug.Log("No item in the slot.");
        }
    }
}
