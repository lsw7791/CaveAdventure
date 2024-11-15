using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetItem(Inventory inventory, ItemSO item)
    {
        inventory.AddItem(item);
        Debug.Log($"{item.itemName}");
    }
}
