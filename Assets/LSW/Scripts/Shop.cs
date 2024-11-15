using UnityEngine;
using static UnityEditor.Progress;

public class Shop : MonoBehaviour
{
    public ItemSO item;

    public void PurchaseItem(Inventory playerInventory)
    {
        // 아이템 구매
        ItemManager.Instance.GetItem(playerInventory, item, ItemGetting.Purchase);
    }
}
