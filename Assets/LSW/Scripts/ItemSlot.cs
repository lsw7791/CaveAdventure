using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public int index;  // 슬롯의 고유 인덱스 번호
    private Image slotImage;  // 슬롯의 Icon 이미지
    public ItemSO currentItem;  // 현재 슬롯의 아이템
    public UIEquip uiEquip;
    public UIInventory uiInventory;
    private ItemUse itemuse;

    void Awake()
    {
        uiInventory = FindObjectOfType<UIInventory>();
        itemuse = FindObjectOfType<ItemUse>(); // ItemUse 인스턴스 자동 찾기

        // Icon이라는 이름의 자식 Image 컴포넌트를 찾아서 할당
        slotImage = transform.Find("Icon").GetComponent<Image>();

        if (slotImage != null)
        {
            slotImage.enabled = false;  // 초기에는 비활성화된 상태
        }
    }

    // 아이템을 슬롯에 설정하는 메서드
    public void SetItem(ItemSO item)
    {
        currentItem = item;
        if (slotImage != null && item != null)
        {
            slotImage.sprite = item.icon;  // 아이템 아이콘 설정
            slotImage.enabled = true;  // 이미지 활성화
        }
        else if (slotImage != null)
        {
            slotImage.enabled = false;  // 아이템이 없을 경우 비활성화
        }
    }

    // 아이콘 클릭 시 호출될 메서드
    public void OnClickIcon()
    {
        if (currentItem != null && uiInventory != null)
        {
            // 아이템의 이름과 설명을 UI에 표시
            uiInventory.itemNameText.text = currentItem.itemName;
            uiInventory.itemDescriptionText.text = currentItem.description;
            itemuse.slot = this;
        }
    }
}
