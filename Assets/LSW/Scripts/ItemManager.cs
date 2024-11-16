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

    // 아이템을 획득하는 메서드
    public void GetItem(Inventory inventory, ItemSO item, ItemGetting gettingMethod)
    {
        inventory.AddItem(item); 
    }
}
