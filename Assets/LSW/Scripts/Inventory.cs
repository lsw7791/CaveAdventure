using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemSO> items = new List<ItemSO>();  // 아이템 리스트

    // 아이템을 인벤토리에 추가하는 메서드
    public void AddItem(ItemSO item)
    {
        items.Add(item);  // 아이템을 리스트에 추가
        Debug.Log("Item added: " + item.itemName);  // 아이템이 추가되었음을 로그로 출력       
    }

    public void RemoveItem(ItemSO item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);  // 리스트에서 아이템 제거
            Debug.Log("Item removed: " + item.itemName);  // 아이템이 제거되었음을 로그로 출력
        }
        else
        {
            Debug.Log("Item not found in inventory.");
        }
    }

    // 특정 슬롯에 해당하는 아이템을 가져오는 메서드
    public ItemSO GetItemInSlot(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < items.Count)
        {
            return items[slotIndex];  // 해당 인덱스에 있는 아이템 반환
        }
        else
        {
            Debug.Log("Invalid slot index.");
            return null;  // 유효하지 않은 인덱스일 경우 null 반환
        }
    }
}
