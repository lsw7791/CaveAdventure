using UnityEngine;

public class PickUp : MonoBehaviour
{
    public ItemSO item;  // 주울 아이템

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory playerInventory = other.GetComponent<Inventory>();
            ItemManager.Instance.GetItem(playerInventory, item, ItemGetting.Pickup);  // 아이템 획득 방법을 전달
            Destroy(gameObject);  // 아이템 오브젝트 제거
        }
    }
}
