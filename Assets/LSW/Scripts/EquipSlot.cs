using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipSlot : MonoBehaviour, IPointerClickHandler
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
            // 기존에 장착된 아이템을 인벤토리에 반환
            if (currentItem != null)
            {
                inventory.AddItem(currentItem);
            }

            // 현재 슬롯에 새로운 아이템 장착
            currentItem = item;
            inventory.RemoveItem(item);  // 인벤토리에서 해당 아이템 제거
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

    // 슬롯 클릭 이벤트 처리 (우클릭 시 장착 해제)
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)  // 우클릭 시
        {
            UnequipItem();  // 현재 슬롯의 아이템 해제
        }
        else if (eventData.button == PointerEventData.InputButton.Left)  // 좌클릭 시
        {
            // 필요 시 좌클릭 동작 추가 (예: 아이템 상세보기)
            Debug.Log("Left-clicked on slot " + index);
        }
    }

    // 슬롯이 비어 있는지 확인하는 메서드
    public bool IsEmpty()
    {
        return currentItem == null;
    }
}
