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
}
