using UnityEngine;

public class PickUp : MonoBehaviour
{
    public ItemSO item; 

    // 아이템을 주울 때
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory playerInventory = other.GetComponent<Inventory>();

            ItemManager.Instance.GetItem(playerInventory, item);

            Destroy(gameObject);
        }
    }
}
