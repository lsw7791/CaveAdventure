using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    public int index;  // 슬롯의 고유 인덱스
    private ItemSO currentItem;  // 현재 슬롯에 장착된 아이템
    public Inventory inventory;  // 인벤토리 참조

    private Image iconImage;  // 아이콘 이미지를 표시하는 컴포넌트

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        iconImage = transform.Find("Icon").GetComponent<Image>();

        if (iconImage != null)
        {
            iconImage.enabled = false;  // 초기에는 아이콘을 비활성화
        }
    }

    // 아이템 장착 메서드
    public void EquipItem(ItemSO item)
    {
        if (item != null)
        {
            currentItem = item;
            iconImage.enabled = true;  // 아이콘 활성화
            iconImage.sprite = item.icon;
            Debug.Log("Equipped item in slot " + index + ": " + item.itemName);
        }
        else
        {
            Debug.Log("No item to equip.");
        }
    }

    // 아이템 해제 메서드
    public void UnequipItem()
    {
        if (currentItem != null && iconImage.enabled)
        {
            inventory.AddItem(currentItem);  // 인벤토리에 아이템 추가
            Debug.Log("Unequipped item from slot " + index + ": " + currentItem.itemName);

            currentItem = null;  // 슬롯의 아이템 정보 제거
            iconImage.sprite = null;  // 아이콘 제거
            iconImage.enabled = false;  // 아이콘 비활성화
        }
        else
        {
            Debug.Log("No item equipped in this slot.");
        }
    }

    // Update 메서드에서 우클릭 감지 (슬롯 내 아이템 해제)
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))  // 우클릭 시
        {
            UnequipItem();  // 현재 슬롯의 아이템 해제
        }
    }

    public bool IsEmpty()
    {
        return currentItem == null;
    }
}
