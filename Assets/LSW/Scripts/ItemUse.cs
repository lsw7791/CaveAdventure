using System;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    public ItemSlot slot;
    private UIInventory uIInventory;
    private EquipSlot[] equipSlots;  // 장비 슬롯 배열

    private void Awake()
    {
        uIInventory = FindObjectOfType<UIInventory>();
    }

    // 장비 슬롯 배열을 설정하는 메서드
    public void SetEquipSlots(EquipSlot[] slots)
    {
        equipSlots = slots;
        Debug.Log("Equip slots assigned.");
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
            ItemSO item = slot.currentItem; // ItemSO 가져오기
            Debug.Log("Using item: " + item.name);

            EquipSlot emptySlot = FindEmptyEquipSlot();  // 비어있는 슬롯 찾기

            if (emptySlot != null)
            {
                emptySlot.EquipItem(item);  // 비어 있는 슬롯에 아이템 장착

                // 슬롯 비우기
                uIInventory.ClearSlot(slot.index);
            }
            else
            {
                Debug.Log("No empty equip slot available.");
            }
        }
        else
        {
            Debug.Log("No item in the slot.");
        }
    }

    // 비어 있는 장비 슬롯을 찾는 메서드
    private EquipSlot FindEmptyEquipSlot()
    {
        foreach (EquipSlot equipSlot in equipSlots)
        {
            if (equipSlot.IsEmpty())  // IsEmpty 메서드는 슬롯이 비어 있는지 여부를 반환
            {
                return equipSlot;
            }
        }
        return null;
    }
}
