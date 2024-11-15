using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> itemSlots; 

    public void UpdateInventory(List<ItemSO> items)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i < items.Count)
            {
                itemSlots[i].GetComponent<Image>().sprite = items[i].icon; 
                itemSlots[i].GetComponentInChildren<Text>().text = items[i].itemName; 
                itemSlots[i].SetActive(true);
            }
            else
            {
                itemSlots[i].SetActive(false); 
            }
        }
    }
}
