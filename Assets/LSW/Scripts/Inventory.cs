using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemSO> items = new List<ItemSO>();

    public void AddItem(ItemSO item)
    {
        items.Add(item);
        Debug.Log($"{item.itemName} added to inventory.");
        // 필요한 경우, isStackable 체크 후 중복 처리 로직 추가
    }
}
