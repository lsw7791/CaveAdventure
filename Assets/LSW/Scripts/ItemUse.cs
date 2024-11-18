using System;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    public ItemSlot slot;
    private UIInventory uIInventory;
    private UIEquip uIEquip;  // UIEquip 인스턴스 추가

    private void Awake()
    {
        uIInventory = FindObjectOfType<UIInventory>();
        uIEquip = FindObjectOfType<UIEquip>();  // UIEquip 초기화
    }

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

            // UIEquip에 아이템을 전달하여 장착 UI에 표시
            uIEquip.EquipItem(item, slot.index);  // 슬롯 인덱스를 전달

            // 슬롯 비우기
            uIInventory.ClearSlot(slot.index);
        }
        else
        {
            Debug.Log("No item in the slot.");
        }
    }
}
